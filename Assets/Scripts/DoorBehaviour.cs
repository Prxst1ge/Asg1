using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    private bool isOpen = false;
    public void Interact()
    {
        Vector3 doorRotation = transform.eulerAngles;

        if (!isOpen)
        {
            doorRotation.y -= 90;
            isOpen = true;
        }
        else
        {
            doorRotation.y += 90;
            isOpen = false;
        }

        transform.eulerAngles = doorRotation;
    }
}
