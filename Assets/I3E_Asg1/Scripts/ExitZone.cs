/*
 * Author: Javier
 * Date: 14 June 2025
 * Description: Detects when the player enters the final exit zone.
 *              If the player has the key, it displays the end screen with final stats.
 */

using UnityEngine;
using TMPro;

/// <summary>
/// Triggers the end screen when the player enters the exit zone with the key.
/// </summary>
public class ExitZone : MonoBehaviour
{
    [SerializeField] private GameObject endScreenPanel; // The UI panel to show when game ends
    [SerializeField] private TextMeshProUGUI finalScoreText; // Text field to show final score
    [SerializeField] private TextMeshProUGUI itemsCollectedText; // Text field to show collected items

    /// <summary>
    /// Detects when the player enters the trigger zone.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the player's interaction data
            InteractionController controller = FindObjectOfType<InteractionController>();

            // Check if the player has the key required to escape
            if (controller != null && controller.hasKey)
            {
                // Show end screen UI
                endScreenPanel.SetActive(true);

                // Display final score and total items collected
                finalScoreText.text = "Final Score: " + controller.totalScore;
                itemsCollectedText.text = "Total Items Collected: " + controller.totalCollected + " / 12";

                Debug.Log("Player escaped the facility!");
            }
        }
    }
}

