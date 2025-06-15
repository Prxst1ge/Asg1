/*
 * Author: Javier
 * Date: 14 June 2025
 * Description: Represents a collectible Lava Sphere object that increases the player's collectible count and score when interacted with.
 */

using UnityEngine;

/// <summary>
/// Collectible Lava Sphere that adds to the collectible count and score when interacted with.
/// </summary>
public class LavaSphereBehaviour : MonoBehaviour, IInteractable
{
    /// <summary>
    /// Score value this Lava Sphere contributes when collected.
    /// </summary>
    [SerializeField] private int score = 1;

    /// <summary>
    /// Sound effect to play when the sphere is collected.
    /// </summary>
    [SerializeField] private AudioClip pickupSFX;

    /// <summary>
    /// Reference to this object's MeshRenderer.
    /// </summary>
    private MeshRenderer myMeshRenderer;

    /// <summary>
    /// Material used to visually highlight this object when targeted.
    /// </summary>
    [SerializeField] private Material highlightMat;

    /// <summary>
    /// Stores the original material before highlighting.
    /// </summary>
    private Material originalMat;

    /// <summary>
    /// Called on start. Stores the mesh renderer and original material.
    /// </summary>
    void Start()
    {
        myMeshRenderer = GetComponent<MeshRenderer>();
        originalMat = myMeshRenderer.material;
    }

    /// <summary>
    /// Called when the player looks at this object. Changes the material to highlight.
    /// </summary>
    public void Highlight()
    {
        myMeshRenderer.material = highlightMat;
    }

    /// <summary>
    /// Called when the player stops looking at this object. Restores the original material.
    /// </summary>
    public void Unhighlight()
    {
        myMeshRenderer.material = originalMat;
    }

    /// <summary>
    /// Called when the player interacts with the Lava Sphere.
    /// Adds to the player's collectible count and score, plays a sound, and destroys the object.
    /// </summary>
    public void Interact()
    {
        InteractionController controller = FindObjectOfType<InteractionController>();
        if (controller != null)
        {
            controller.AddCollectible();
            controller.totalScore += score;
        }

        AudioSource.PlayClipAtPoint(pickupSFX, transform.position);
        Destroy(gameObject);
    }
}





