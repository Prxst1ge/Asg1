using UnityEngine;

/// <summary>
/// Power Cell that can only be collected once all collectibles are found.
/// </summary>
public class PowerCellBehaviour : MonoBehaviour, IInteractable
{
    private MeshRenderer myMeshRenderer; // Reference to this object's renderer

    [SerializeField]
    private Material highlightMat; // Material to use when the object is highlighted

    private Material originalMat; // Original material (for unhighlighting)

    void Start()
    {
        // Get the MeshRenderer on this GameObject
        myMeshRenderer = GetComponent<MeshRenderer>();

        // Store the original material
        originalMat = myMeshRenderer.material;
    }

    // Called when the player looks at the object
    public void Highlight()
    {
        // Change the material to the highlight material
        myMeshRenderer.material = highlightMat;
    }

    // Called when the player looks away
    public void Unhighlight()
    {
        // Restore the original material
        myMeshRenderer.material = originalMat;
    }

    // Called when the player presses interact while aiming at this object
    public void Interact()
    {
        // Find the InteractionController to access the collectible count
        InteractionController controller = FindObjectOfType<InteractionController>();

        // Only allow collection if the player has collected 9 items
        if (controller.totalCollected >= 9)
        {
            Debug.Log("Power Cell Collected!");

            // Remove highlight and mark power cell as collected
            Unhighlight();
            controller.hasPowerCell = true;

            // Remove the power cell from the scene
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("You need to collect all 9 items first!");
        }
    }
}


