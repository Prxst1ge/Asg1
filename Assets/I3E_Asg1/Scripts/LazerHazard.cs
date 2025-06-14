using UnityEngine;

/// <summary>
/// Instantly kills the player unless they have the shield.
/// </summary>
public class LazerHazard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InteractionController controller = FindObjectOfType<InteractionController>();

            // If the player does NOT have a shield they will take fatal damage
            if (controller != null && !controller.hasShield)
            {
                Debug.Log("Player hit by laser — no shield! Insta-death.");
                PlayerHealth health = other.GetComponent<PlayerHealth>();
                if (health != null)
                {
                    health.TakeDamage(999); // Instant kill
                }
            }
            else
            {
                Debug.Log("Player passed through laser with shield!");
            }
        }
    }
}


