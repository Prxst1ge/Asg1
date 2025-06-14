using UnityEngine;
using System.Collections;

/// <summary>
/// Applies damage over time to the player while in the poison zone.
/// </summary>
public class PoisonHazard : MonoBehaviour
{
    [SerializeField] private float damageAmount = 30f; // Total damage dealt
    [SerializeField] private float duration = 5f;       // How long the poison lasts

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

    IEnumerator DamageOverTimeCoroutine(PlayerHealth player, float damageAmount, float duration)
    {
        float amountDamaged = 0;
        float damagePerTick = damageAmount / duration;

        while (amountDamaged < damageAmount && player != null)
        {
            player.TakeDamage(Mathf.RoundToInt(damagePerTick));
            Debug.Log("Current HP: " + player.GetCurrentHealth()); // Optional debug
            amountDamaged += damagePerTick;
            yield return new WaitForSeconds(1f);
        }
    }
}

