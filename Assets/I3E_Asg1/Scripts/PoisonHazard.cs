/*
 * Author: Javier
 * Date: 14 June 2025
 * Description: This script applies damage over time (DOT) to the player while inside a poison zone.
 *              Damage is dealt gradually using a coroutine over a defined duration.
 */

using UnityEngine;
using System.Collections;

/// <summary>
/// Applies damage over time to the player while in the poison zone.
/// </summary>
public class PoisonHazard : MonoBehaviour
{
    [SerializeField] private float damageAmount = 30f;  // Total amount of damage the poison does
    [SerializeField] private float duration = 5f;       // How long it takes to apply all the poison damage

    /// <summary>
    /// Triggered when the player enters the poison trigger zone.
    /// Starts the DOT coroutine if player is detected.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered poison zone!");

            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                StartCoroutine(DamageOverTimeCoroutine(health, damageAmount, duration));
            }
        }
    }

    /// <summary>
    /// Coroutine that applies poison damage gradually over time.
    /// </summary>
    IEnumerator DamageOverTimeCoroutine(PlayerHealth player, float damageAmount, float duration)
    {
        float amountDamaged = 0;
        float damagePerTick = damageAmount / duration;

        while (amountDamaged < damageAmount && player != null)
        {
            player.TakeDamage(Mathf.RoundToInt(damagePerTick));
            amountDamaged += damagePerTick;
            yield return new WaitForSeconds(1f); // Waits 1 second between damage ticks
        }
    }
}


