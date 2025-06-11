using UnityEngine;
/// <summary>
/// Handles raycast-based interaction and player logic.
/// </summary>
public class InteractionController : MonoBehaviour

{
    [Header("Raycast Settings")]
    [SerializeField] Transform spawnPoint;
    [SerializeField] float interactionDistance = 5f;
    public int totalCollected = 0;
    public bool hasPowerCell = false;

    IInteractable currentTarget;

    void Update()
    {
        Debug.DrawRay(spawnPoint.position, spawnPoint.forward * interactionDistance, Color.green);

        if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out RaycastHit hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null && interactable != currentTarget)
            {
                // Only unhighlight if the target still exists
                if (currentTarget != null)
                {
                    // prevent trying to access a destroyed object
                    MonoBehaviour mono = currentTarget as MonoBehaviour;
                    if (mono != null)
                    {
                        currentTarget.Unhighlight();
                    }
                }

                currentTarget = interactable;
                currentTarget.Highlight();
            }
        }
        else
        {
            if (currentTarget != null)
            {
                // prevent error after destroy
                MonoBehaviour mono = currentTarget as MonoBehaviour;
                if (mono != null)
                {
                    currentTarget.Unhighlight();
                }

                currentTarget = null;
            }
        }
    }


    public void OnInteract()
    {
        if (currentTarget != null)
        {
            currentTarget.Interact();
            currentTarget = null; 
        }
    }
    public void AddCollectible()
{
    totalCollected++;
    Debug.Log("Collected: " + totalCollected);
}
}