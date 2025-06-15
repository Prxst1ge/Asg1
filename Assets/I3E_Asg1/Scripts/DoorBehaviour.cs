/*
 * Author: Javier
 * Date: 14 June 2025
 * Description: Controls a door that opens when the player has collected at least 5 collectibles. The door auto-closes when the player leaves the trigger zone. Includes door SFX.
 */

using UnityEngine;

/// <summary>
/// Door that opens if the player has at least 5 collectibles.
/// Closes when the player exits the trigger zone.
/// </summary>
public class DoorBehaviour : MonoBehaviour, IInteractable
{
    private bool isOpen = false;

    /// <summary>
    /// Audio part of door
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Audio used for door
    /// </summary>
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Called when the player interacts with the door.
    /// Checks if the player has collected enough items before opening.
    /// </summary>
    public void Interact()
    {
        Debug.Log("Door Interacted!");

        // Requirement: Must have collected at least 5 items
        InteractionController controller = FindObjectOfType<InteractionController>();
        if (controller != null && controller.totalCollected >= 5)
        {
            if (!isOpen)
            {
                OpenDoor();
            }
        }
        else
        {
            Debug.Log("You need at least 5 collectibles to open this door.");
        }
    }

    /// <summary>
    /// Rotates the door to open it and plays Door SFX
    /// </summary>
    void OpenDoor()
    {
        Vector3 doorRotation = transform.eulerAngles;
        doorRotation.y -= 90;
        transform.eulerAngles = doorRotation;
        isOpen = true;

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    /// <summary>
    /// Rotates the door back to close it.
    /// </summary>
    void CloseDoor()
    {
        Vector3 doorRotation = transform.eulerAngles;
        doorRotation.y += 90;
        transform.eulerAngles = doorRotation;
        isOpen = false;
    }

    /// <summary>
    /// Closes the door automatically when the player exits the trigger zone.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isOpen)
        {
            Debug.Log("Player exited door zone — closing now.");
            CloseDoor();
        }
    }

    // Required for IInteractable interface (not used here)
    public void Highlight() { }
    public void Unhighlight() { }
}




