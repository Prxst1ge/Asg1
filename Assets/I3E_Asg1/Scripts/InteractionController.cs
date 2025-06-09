using UnityEngine;
/// <summary>
/// Handles raycast-based interaction and player logic.
/// </summary>
public class InteractionController : MonoBehaviour

{
    [Header("Raycast Settings")]
    [SerializeField] Transform spawnPoint;
    [SerializeField] float interactionDistance = 5f;

    IInteractable currentTarget;

    void Update()
    {
        Debug.DrawRay(spawnPoint.position, spawnPoint.forward * interactionDistance, Color.green);

        // Raycast forward from spawnPoint
        if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out RaycastHit hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            // If looking at a new object
            if (interactable != null && interactable != currentTarget)
            {
                // Unhighlight the old target
                if (currentTarget != null)
                {
                    currentTarget.Unhighlight();
                }

                // Set and highlight the new one
                currentTarget = interactable;
                currentTarget.Highlight();
            }
        }
        else
        {
            // If not looking at anything interactable
            if (currentTarget != null)
            {
                currentTarget.Unhighlight();
                currentTarget = null;
            }
        }
    }

    public void OnInteract()
    {
        if (currentTarget != null)
        {
            currentTarget.Interact();
        }
    }
}