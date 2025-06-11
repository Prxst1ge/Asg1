using UnityEngine;

/// <summary>
/// Collectible Lava Sphere that adds to the collectible count when interacted with.
/// </summary>
public class LavaSphereBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private int value = 1;

    private MeshRenderer myMeshRenderer;

    [SerializeField]
    private Material highlightMat;

    private Material originalMat;

    void Start()
    {
        myMeshRenderer = GetComponent<MeshRenderer>();

        // Store the original material
        originalMat = myMeshRenderer.material;
    }

    public void Highlight()
    {
        myMeshRenderer.material = highlightMat;
    }

    public void Unhighlight()
    {
        myMeshRenderer.material = originalMat;
    }

    public void Interact()
    {
        Debug.Log("Lava Sphere Interacted!");

        // Clear highlight BEFORE destroying
        Unhighlight();

        // Add to counter
        FindObjectOfType<InteractionController>().AddCollectible();

        // Now safe to destroy
        Destroy(gameObject);
    }
}



