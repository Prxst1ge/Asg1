/*
 * Author: Javier
 * Date: 14 June 2025
 * Description: Controls a door that only opens if the player has collected the Power Cell.
 *              The door auto-closes when the player exits the trigger zone. Includes door SFX.
 */

using UnityEngine;

/// <summary>
/// Door that only opens if the player has collected the Power Cell.
/// Auto-closes when player leaves the trigger.
/// </summary>
public class DoorBehaviour1 : MonoBehaviour, IInteractable
{
    private bool isOpen = false;

    /// <summary>
    /// Door SFX
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Door SFX
    /// </summary>
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Called when the player interacts with the door.
    /// Checks if the player has the Power Cell before allowing it to open.
    /// </summary>
    public void Interact()
    {
        Debug.Log("Door Interacted!");

        InteractionController controller = FindObjectOfType<InteractionController>();

        if (controller != null && controller.hasPowerCell)
        {
            if (!isOpen)
            {
                OpenDoor();
            }
        }
        else
        {
            Debug.Log("Obtain Power Cell to unlock the door!");
        }
    }

    /// <summary>
    /// Rotates the door open and plays sound.
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
    /// Rotates the door back to its closed position.
    /// </summary>
    void CloseDoor()
    {
        Vector3 doorRotation = transform.eulerAngles;
        doorRotation.y += 90;
        transform.eulerAngles = doorRotation;
        isOpen = false;
    }

    /// <summary>
    /// Automatically closes the door when the player exits the trigger zone.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isOpen)
        {
            Debug.Log("Player exited door zone — closing now.");
            CloseDoor();
        }
    }

    // Required by IInteractable, but not used in this case.
    public void Highlight() { }
    public void Unhighlight() { }
}

