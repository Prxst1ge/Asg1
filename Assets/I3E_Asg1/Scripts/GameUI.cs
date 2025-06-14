using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectibleText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private InteractionController controller;
    private PlayerHealth playerHealth;

    void Start()
    {
        controller = FindObjectOfType<InteractionController>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        if (controller != null)
        {
            collectibleText.text = "Collected: " + controller.totalCollected + " / 10";
            scoreText.text = "Score: " + controller.totalScore;
        }

        if (playerHealth != null)
        {
            healthText.text = "HP: " + playerHealth.GetCurrentHealth() + " / 100";
        }
    }
}


