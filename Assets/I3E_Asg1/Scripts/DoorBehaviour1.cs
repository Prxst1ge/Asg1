using UnityEngine;

/// <summary>
/// Door that only opens if the player has collected the Power Cell.
/// Auto-closes when player leaves the trigger.
/// </summary>
public class DoorBehaviour1 : MonoBehaviour, IInteractable
{
    private bool isOpen = false;

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
            Debug.Log("You need the Power Cell to open this door.");
        }
    }

    void OpenDoor()
    {
        Vector3 doorRotation = transform.eulerAngles;
        doorRotation.y -= 90;
        transform.eulerAngles = doorRotation;
        isOpen = true;
    }

    void CloseDoor()
    {
        Vector3 doorRotation = transform.eulerAngles;
        doorRotation.y += 90;
        transform.eulerAngles = doorRotation;
        isOpen = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isOpen)
        {
            Debug.Log("Player exited door zone — closing now.");
            CloseDoor();
        }
    }

    public void Highlight() { }
    public void Unhighlight() { }
}

