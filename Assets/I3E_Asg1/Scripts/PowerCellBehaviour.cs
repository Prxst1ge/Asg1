using UnityEngine;

/// <summary>
/// Power Cell that can only be collected once all collectibles are found.
/// </summary>
public class PowerCellBehaviour : MonoBehaviour, IInteractable
{
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
        InteractionController controller = FindObjectOfType<InteractionController>();

        if (controller.totalCollected >= 9)
        {
            Debug.Log("Power Cell Collected!");
            Unhighlight();
            controller.hasPowerCell = true; 
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("You need to collect all 9 items first!");
        }
    }
}

