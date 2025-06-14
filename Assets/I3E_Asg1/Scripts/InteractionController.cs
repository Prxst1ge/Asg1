using UnityEngine;

/// <summary>
/// Handles raycast-based interaction and player logic.
/// </summary>
public class InteractionController : MonoBehaviour
{
    [Header("Raycast Settings")]
    [SerializeField] Transform spawnPoint; 
    [SerializeField] float interactionDistance = 5f; // How far the ray can reach
    public int totalScore = 0; //Tracks the total score of the player

    public int totalCollected = 0; // Tracks how many collectibles the player has picked up
    public bool hasPowerCell = false; // Tracks whether the player has collected the Power Cell
    public bool hasShield = false; // Tracks whether the player has collected the Shield
    public bool hasKey = false; //Tracks whether the player has collected the Key


    IInteractable currentTarget; // The object the player is currently aiming at

    void Update()
    {
        // Draw a green ray in the Scene view for debugging
        Debug.DrawRay(spawnPoint.position, spawnPoint.forward * interactionDistance, Color.green);

        // Cast a ray forward from the spawn point
        if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out RaycastHit hit, interactionDistance))
        {
            // Check if the object hit by the ray has an IInteractable script
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            // If looking at a new object
            if (interactable != null && interactable != currentTarget)
            {
                // Unhighlight the previous object if it still exists
                if (currentTarget != null)
                {
                    MonoBehaviour mono = currentTarget as MonoBehaviour;
                    if (mono != null)
                    {
                        currentTarget.Unhighlight();
                    }
                }

                // Set the new target and highlight it
                currentTarget = interactable;
                currentTarget.Highlight();
            }
        }
        else
        {
            // If not looking at anything interactable
            if (currentTarget != null)
            {
                // Unhighlight the current object if it hasn't been destroyed
                MonoBehaviour mono = currentTarget as MonoBehaviour;
                if (mono != null)
                {
                    currentTarget.Unhighlight();
                }

                // Clear the current target
                currentTarget = null;
            }
        }
    }

    // Called when the player presses the Interact key
    public void OnInteract()
    {
        if (currentTarget != null)
        {
            // Trigger the object's interaction method
            currentTarget.Interact();

            // Clear the target (useful if the object gets destroyed)
            currentTarget = null;
        }
    }

    // Called by collectibles when collected
    public void AddCollectible()
    {
        totalCollected++;
        totalScore++;
        Debug.Log("Collected: " + totalCollected + " | Score: " + totalScore);
    }

}
