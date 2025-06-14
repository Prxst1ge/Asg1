using UnityEngine;

/// <summary>
/// Collectible Lava Sphere that adds to the collectible count when interacted with.
/// </summary>
public class LavaSphereBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private int score = 1; //can be used to give different scores

    private MeshRenderer myMeshRenderer; 

    [SerializeField]
    private Material highlightMat; // Material used to highlight the sphere when looked at

    private Material originalMat; // Stores the original material of the sphere

    void Start()
    {
        // Get the MeshRenderer component on this GameObject
        myMeshRenderer = GetComponent<MeshRenderer>();

        // Store the original material to restore later
        originalMat = myMeshRenderer.material;
    }

    // Called when the player is looking at this object
    public void Highlight()
    {
        // Change the material to the highlight version
        myMeshRenderer.material = highlightMat;
    }

    // Called when the player looks away from this object
    public void Unhighlight()
    {
        // Restore the original material
        myMeshRenderer.material = originalMat;
    }

    // Called when the player interacts with this object
    public void Interact()
    {
        Debug.Log("Lava Sphere Interacted!");

        // Remove the highlight before destroying the object
        Unhighlight();

        // Increase the player's collectible count
        FindObjectOfType<InteractionController>().AddCollectible();

        // Destroy the object from the scene
        Destroy(gameObject);
    }
}




