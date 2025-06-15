/*
 * Author: Javier
 * Date: 14 June 2025
 * Description: Applies damage over time to the player while in the lava hazard zone using a coroutine.
 */

using UnityEngine;
using System.Collections;

/// <summary>
/// Applies damage over time to the player while in the lava zone.
/// </summary>
public class LavaHazard : MonoBehaviour
{
    /// <summary>
    /// Total damage the player takes over the entire duration.
    /// </summary>
    [SerializeField] private float damageAmount = 50f;

    /// <summary>
    /// Duration over which the damage is applied.
    /// </summary>
    [SerializeField] private float duration = 5f;

    /// <summary>
    /// Called when the player first enters the lava trigger zone.
    /// </summary>

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched lava!");

            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                StartCoroutine(DamageOverTimeCoroutine(health, damageAmount, duration));
            }
        }
    }

    /// <summary>
    /// Coroutine that applies damage over time to the player.
    /// </summary>
    /// 
    IEnumerator DamageOverTimeCoroutine(PlayerHealth player, float damageAmount, float duration)
    {
        float amountDamaged = 0;
        float damagePerTick = damageAmount / duration;

        while (amountDamaged < damageAmount && player != null)
        {
            player.TakeDamage(Mathf.RoundToInt(damagePerTick));
            Debug.Log("Current HP: " + player.GetCurrentHealth());
            amountDamaged += damagePerTick;
            yield return new WaitForSeconds(1f);
        }
    }
}


