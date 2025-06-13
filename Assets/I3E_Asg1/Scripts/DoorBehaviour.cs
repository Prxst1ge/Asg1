using UnityEngine;

public class DoorBehaviour : MonoBehaviour, IInteractable
{
    private bool isOpen = false;

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




