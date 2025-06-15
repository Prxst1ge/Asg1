/*
 * Author: Javier
 * Date: 14 June 2025
 * Description: This script handles the lazer hazard behavior. If the player enters the laser
 *              zone without a shield, they are instantly killed. If they have a shield,
 *              they can safely pass through.
 */

using UnityEngine;

/// <summary>
/// Instantly kills the player unless they have the shield.
/// </summary>
public class LazerHazard : MonoBehaviour
{
    /// <summary>
    /// Called when another collider enters the laser's trigger zone.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        // Only apply to player
        if (other.CompareTag("Player"))
        {
            // Get reference to InteractionController
            InteractionController controller = FindObjectOfType<InteractionController>();

            // If player doesn't have the shield, instantly kill
            if (controller != null && !controller.hasShield)
            {
                Debug.Log("Player hit by laser — no shield! Insta-death.");
                PlayerHealth health = other.GetComponent<PlayerHealth>();
                if (health != null)
                {
                    health.TakeDamage(999); // Deal massive damage to ensure death
                }
            }
            else
            {
                Debug.Log("Player passed through laser with shield!");
            }
        }
    }
}



