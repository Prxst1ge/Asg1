using UnityEngine;

/// <summary>
/// Energy Cube collectible that adds to the total collectible count when interacted with.
/// </summary>
public class EnergyCubeBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private int value = 1;

    private MeshRenderer myMeshRenderer;

    [SerializeField]
    private Material highlightMat;

    private Material originalMat;

    void Start()
    {
        myMeshRenderer = GetComponent<MeshRenderer>();
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
        Debug.Log("Energy Cube Collected!");
        Unhighlight();
        FindObjectOfType<InteractionController>().AddCollectible(); // same method used by LavaSphere
        Destroy(gameObject);
    }
}
