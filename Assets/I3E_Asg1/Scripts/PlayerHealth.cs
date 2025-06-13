using UnityEngine;

/// <summary>
/// Manages the player's health and handles respawning when health reaches zero.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; // Maximum health value (can edit in Inspector)
    private int currentHealth; // Tracks current health

    [SerializeField] private Transform respawnPoint; // Reference to where the player should respawn

    void Start()
    {
        // Set current health to full health at the start of the game
        currentHealth = maxHealth;
    }

    // Called by hazards to reduce health
    public void TakeDamage(int amount)
    {
        // Subtract damage from current health
        currentHealth -= amount;

        // Print current health to console
        Debug.Log("Player took damage. Current HP: " + currentHealth);

        // If health is zero or below, respawn the player
        if (currentHealth <= 0)
        {
            Respawn();
        }
    }

    // Moves the player back to the respawn point and resets health
    void Respawn()
    {
        Debug.Log("You have died.");

        // Reset health to full
        currentHealth = maxHealth;

        // Get the CharacterController component
        CharacterController controller = GetComponent<CharacterController>();

        if (controller != null)
        {
            // Disable the CharacterController to allow position to change
            controller.enabled = false;

            // Move the player to the respawn position
            transform.position = respawnPoint.position;

            // Re-enable the CharacterController
            controller.enabled = true;
        }
        else
        {
            // If no CharacterController, just move the player
            transform.position = respawnPoint.position;
        }
    }
   
    // Returns the current health value (used by poison debug)
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

}


