using UnityEngine;

/// <summary>
/// Instantly kills the player upon contact with the laser.
/// </summary>
public class LazerHazard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit by laser — instant death!");

            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(999); // Big enough to guarantee death
            }
        }
    }
}

