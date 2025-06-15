/*
 * Author: Javier
 * Date: 14 June 2025
 * Description: Grants the player a shield when collected, allowing them to pass through
 *              lazer hazards safely. Plays a sound and increases collectible count and score.
 */

using UnityEngine;

/// <summary>
/// Grants the player a shield when collected.
/// </summary>
public class ShieldPickup : MonoBehaviour, IInteractable
{
    [SerializeField] private int score = 1; // Score awarded for collecting the shield
    [SerializeField] private AudioClip sfxClip; // Sound effect to play when collected

    /// <summary>
    /// Called when the player interacts with the shield.
    /// </summary>
    public void Interact()
    {
        // Get reference to the InteractionController
        InteractionController controller = FindObjectOfType<InteractionController>();

        if (controller != null)
        {
            // Grant shield to player
            controller.hasShield = true;

            // Update score and collectible count
            controller.totalScore += score;
            controller.AddCollectible();

            Debug.Log("Shield collected! Laser is now safe to pass through.");

            // Play pickup sound
            AudioSource.PlayClipAtPoint(sfxClip, transform.position);

            // Remove the shield object
            Destroy(gameObject);
        }
    }

    // These are required by the IInteractable interface but not used here
    public void Highlight() { }
    public void Unhighlight() { }
}


