/*
 * Author: Javier
 * Date: 14 June 2025
 * Description: Allows the player to collect the key needed to exit the facility.
 *              Adds to collectible count, updates score, and plays a sound.
 */

using UnityEngine;

/// <summary>
/// Allows the player to collect the key required to exit the facility.
/// </summary>
public class KeyPickup : MonoBehaviour, IInteractable
{
    [SerializeField] private int score = 1; // Score awarded for collecting the key
    [SerializeField] private AudioClip sfxClip; // Sound effect to play on pickup

    /// <summary>
    /// Called when the player interacts with the key object.
    /// </summary>
    public void Interact()
    {
        // Get reference to the InteractionController
        InteractionController controller = FindObjectOfType<InteractionController>();

        if (controller != null)
        {
            controller.hasKey = true;               // Mark that player now has the key
            controller.totalScore += score;         // Add score
            controller.AddCollectible();            // Increase collectible count
            Debug.Log("Key collected! You can now exit the facility.");
            AudioSource.PlayClipAtPoint(sfxClip, transform.position); // Play sound
            Destroy(gameObject);                    // Remove key from scene
        }
    }

    // Not used but required by IInteractable interface
    public void Highlight() { }
    public void Unhighlight() { }
}

