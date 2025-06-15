/*
 * Author: Javier
 * Date: 14 June 2025
 * Description: Energy Cube collectible that increases the player's collectible count and score
 *              upon interaction.
 */

using UnityEngine;

/// <summary>
/// Energy Cube collectible that adds to the total collectible count when interacted with.
/// </summary>
public class EnergyCubeBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private int score = 1; // Score value for this cube
    [SerializeField] private AudioClip sfxClip; // Sound to play when collected

    private MeshRenderer myMeshRenderer; // Reference to this object's renderer

    [SerializeField]
    private Material highlightMat; // Material to show when highlighted

    private Material originalMat; // Stores the default material

    /// <summary>
    /// Called when the object is first created.
    /// Stores original material and gets renderer.
    /// </summary>
    void Start()
    {
        // Get the MeshRenderer component attached to this object
        myMeshRenderer = GetComponent<MeshRenderer>();

        // Store the original material to reset later
        originalMat = myMeshRenderer.material;
    }

    /// <summary>
    /// Called when the player looks at the object.
    /// Changes the material to highlight.
    /// </summary>
    public void Highlight()
    {
        myMeshRenderer.material = highlightMat;
    }

    /// <summary>
    /// Called when the player looks away.
    /// Resets to the original material.
    /// </summary>
    public void Unhighlight()
    {
        myMeshRenderer.material = originalMat;
    }

    /// <summary>
    /// Called when the player interacts with the cube.
    /// Increases score and collectible count, plays sound, and destroys itself.
    /// </summary>
    public void Interact()
    {
        Debug.Log("Energy Cube Collected!");

        Unhighlight();

        // Add to collectible and score
        InteractionController controller = FindObjectOfType<InteractionController>();
        if (controller != null)
        {
            controller.AddCollectible();
            controller.totalScore += score;
        }

        // Play pickup sound
        AudioSource.PlayClipAtPoint(sfxClip, transform.position);

        // Destroy object
        Destroy(gameObject);
    }
}

