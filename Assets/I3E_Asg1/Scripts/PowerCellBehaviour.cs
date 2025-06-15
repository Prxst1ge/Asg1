/*
 * Author: Javier
 * Date: 14 June 2025
 * Description: Power Cell collectible that can only be picked up after all other collectibles are collected.
 *              Increases score and plays a sound upon interaction.
 */

using UnityEngine;

/// <summary>
/// Power Cell that can only be collected once 9 collectibles are found.
/// </summary>
public class PowerCellBehaviour : MonoBehaviour, IInteractable
{
    private MeshRenderer myMeshRenderer; 

    [SerializeField] private int score = 1; // Score value for this object
    [SerializeField] private AudioClip sfxClip; // Sound to play when collected

    [SerializeField]
    private Material highlightMat; // Material to use when highlighted

    private Material originalMat; // Original material to restore after highlight

    /// <summary>
    /// Called when the object starts. Caches renderer and material.
    /// </summary>
    void Start()
    {
        myMeshRenderer = GetComponent<MeshRenderer>();
        originalMat = myMeshRenderer.material;
    }

    /// <summary>
    /// Highlights the object by changing its material.
    /// </summary>
    public void Highlight()
    {
        myMeshRenderer.material = highlightMat;
    }

    /// <summary>
    /// Removes highlight and restores original material.
    /// </summary>
    public void Unhighlight()
    {
        myMeshRenderer.material = originalMat;
    }

    /// <summary>
    /// Only allows interaction if 9 collectibles have been collected.
    /// Increases score, finds that possess the item, and plays SFX.
    /// </summary>
    public void Interact()
    {
        InteractionController controller = FindObjectOfType<InteractionController>();

        if (controller.totalCollected >= 9)
        {
            Debug.Log("Power Cell Collected!");

            Unhighlight();
            controller.hasPowerCell = true;
            controller.AddCollectible();
            controller.totalScore += score;

            AudioSource.PlayClipAtPoint(sfxClip, transform.position);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("You need to collect all 9 items first!");
        }
    }
}



