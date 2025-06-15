/*
 * Author: Javier
 * Date: 14 June 2025
 * Description: Updates the in-game UI to show the player's current collectibles,
 *              health, and score.
 */

using UnityEngine;
using TMPro;

/// <summary>
/// Displays real-time updates for collectibles, health, and score on the UI.
/// </summary>
public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectibleText; // UI element showing how many items the player has collected
    [SerializeField] private TextMeshProUGUI healthText;       // UI element showing player's current health
    [SerializeField] private TextMeshProUGUI scoreText;        // UI element showing player's current score

    private InteractionController controller; // Reference to player interaction tracker
    private PlayerHealth playerHealth;        // Reference to player health tracker

    /// <summary>
    /// Find the necessary player components on scene start.
    /// </summary>
    void Start()
    {
        controller = FindObjectOfType<InteractionController>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    /// <summary>
    /// Continuously update UI values each frame.
    /// </summary>
    void Update()
    {
        if (controller != null)
        {
            collectibleText.text = "Collected: " + controller.totalCollected + " / 12";
            scoreText.text = "Score: " + controller.totalScore;
        }

        if (playerHealth != null)
        {
            healthText.text = "HP: " + playerHealth.GetCurrentHealth() + " / 100";
        }
    }
}


