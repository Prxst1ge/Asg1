/*
 * Author: Javier
 * Date: 14 June 2025
 * Description: Controls raycast-based interactions with objects in front of the player.
 *              Tracks collectible progress and score.
 */

using UnityEngine;

/// <summary>
/// Handles raycast-based interaction and player logic.
/// </summary>
public class InteractionController : MonoBehaviour
{
    [Header("Raycast Settings")]

    /// <summary>
    /// The origin point from where the interaction ray is cast
    /// </summary>
    [SerializeField] Transform spawnPoint;

    /// <summary>
    /// The maximum distance the raycast can reach.
    /// </summary>
    [SerializeField] float interactionDistance = 5f;

    /// <summary>
    /// Tracks the player's total score.
    /// </summary>
    public int totalScore = 0;

    /// <summary>
    /// Number of collectibles the player has collected.
    /// </summary>
    public int totalCollected = 0;

    /// <summary>
    /// Whether the player has collected the Power Cell.
    /// </summary>
    public bool hasPowerCell = false;

    /// <summary>
    /// Whether the player has collected the Shield.
    /// </summary>
    public bool hasShield = false;

    /// <summary>
    /// Whether the player has collected the Key.
    /// </summary>
    public bool hasKey = false;

    /// <summary>
    /// The current object being looked at by the player.
    /// </summary>
    IInteractable currentTarget;

    /// <summary>
    /// Casts a ray every frame to check for interactable objects in front of the player.
    /// </summary>
    void Update()
    {
        Debug.DrawRay(spawnPoint.position, spawnPoint.forward * interactionDistance, Color.green);

        if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out RaycastHit hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null && interactable != currentTarget)
            {
                if (currentTarget != null)
                {
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
                MonoBehaviour mono = currentTarget as MonoBehaviour;
                if (mono != null)
                {
                    currentTarget.Unhighlight();
                }

                currentTarget = null;
            }
        }
    }

    /// <summary>
    /// Called when the player presses the Interact key (E). Triggers interaction with the current object.
    /// </summary>
    public void OnInteract()
    {
        if (currentTarget != null)
        {
            currentTarget.Interact();
            currentTarget = null;
        }
    }

    /// <summary>
    /// Adds to the collectible count when a collectible is collected.
    /// </summary>
    public void AddCollectible()
    {
        totalCollected++;
        Debug.Log("Collected: " + totalCollected + " | Score: " + totalScore);
    }
}
