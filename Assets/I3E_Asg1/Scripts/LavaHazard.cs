using UnityEngine;

/// <summary>
/// Damages the player on contact with lava.
/// </summary>
public class LavaHazard : MonoBehaviour
{
    [SerializeField] private int damageAmount = 25;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched lava!");

            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);
            }
        }
    }
}
