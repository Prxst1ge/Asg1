using UnityEngine;

/// <summary>
/// Energy Cube collectible that adds to the total collectible count when interacted with.
/// </summary>
public class EnergyCubeBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private int score = 1; 

    private MeshRenderer myMeshRenderer; // Reference to this object's renderer

    [SerializeField]
    private Material highlightMat; // Material to show when highlighted

    private Material originalMat; // Stores the default material

    void Start()
    {
        // Get the MeshRenderer component attached to this object
        myMeshRenderer = GetComponent<MeshRenderer>();

        // Store the original material to reset later
        originalMat = myMeshRenderer.material;
    }

    // Called when the player looks at the object
    public void Highlight()
    {
        // Change to highlight material
        myMeshRenderer.material = highlightMat;
    }

    // Called when the player looks away
    public void Unhighlight()
    {
        // Restore the original material
        myMeshRenderer.material = originalMat;
    }

    // Called when the player interacts with this object
    public void Interact()
    {
        Debug.Log("Energy Cube Collected!");

        // Unhighlight before destroying
        Unhighlight();

        // Increase collectible count using InteractionController
        FindObjectOfType<InteractionController>().AddCollectible();

        // Remove the object from the scene
        Destroy(gameObject);
    }
}

