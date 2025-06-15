/*
 * Author: Javier
 * Date: 14 June 2025
 * Description: Manages the player's health system including damage handling, respawn, 
 *              and providing health status for UI display.
 */

using UnityEngine;

/// <summary>
/// Manages the player's health and handles respawning when health reaches zero.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; // Maximum health value editable in the Inspector
    private int currentHealth; // Current runtime health

    [SerializeField] private Transform respawnPoint; // Location where the player respawns

    /// <summary>
    /// Initializes the player's health to maximum at game start.
    /// </summary>
    void Start()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Reduces the player's health when damaged by hazards.
    /// Triggers respawn if health drops to 0 or below.
    /// </summary>
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player took damage. Current HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Respawn();
        }
    }

    /// <summary>
    /// Respawns the player at the specified respawn point and restores full health.
    /// </summary>
    void Respawn()
    {
        Debug.Log("You have died.");
        currentHealth = maxHealth;

        CharacterController controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false; // Temporarily disable controller to move player
            transform.position = respawnPoint.position;
            controller.enabled = true;
        }
        else
        {
            transform.position = respawnPoint.position;
        }
    }

    /// <summary>
    /// Returns the current health value (used by UI).
    /// </summary>
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}



