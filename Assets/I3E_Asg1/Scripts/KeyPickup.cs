using UnityEngine;

/// <summary>
/// Allows the player to collect the key required to exit the facility.
/// </summary>
public class KeyPickup : MonoBehaviour, IInteractable
{
    [SerializeField] private int score = 1; //can be used to give different scores
    public void Interact()
    {
        InteractionController controller = FindObjectOfType<InteractionController>();

        if (controller != null)
        {
            controller.hasKey = true;
            controller.totalScore++;
            Debug.Log("Key collected! You can now exit the facility.");
            Destroy(gameObject);
        }
    }

    public void Highlight() { }
    public void Unhighlight() { }
}
