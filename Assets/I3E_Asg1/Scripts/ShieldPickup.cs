using UnityEngine;

/// <summary>
/// Grants the player a shield when collected.
/// </summary>
public class ShieldPickup : MonoBehaviour, IInteractable
{
    [SerializeField] private int score = 1; //can be used to give different scores 
    public void Interact()
    {
        InteractionController controller = FindObjectOfType<InteractionController>();

        if (controller != null)
        {
            controller.hasShield = true;
            controller.totalScore++;
            Debug.Log("Shield collected! Going through Lasers is now safe.");
            Destroy(gameObject);
        }
    }

    public void Highlight() { }
    public void Unhighlight() { }
}

