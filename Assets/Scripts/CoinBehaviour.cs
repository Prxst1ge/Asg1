using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{ 
    public int value = 10;
    MeshRenderer myMeshRenderer;
    [SerializeField]
    Material highlightMat;
    Material originalMat;
    void Start()
    {
        // Get the MeshRenderer component attached to this GameObject 
        // Store it in  the myMeshRenderer variable
        myMeshRenderer = GetComponent<MeshRenderer>();

        // Store the original color in the coin
        originalMat = myMeshRenderer.material;
    }

    public void Highlight()
    {
        myMeshRenderer.material = highlightMat;
    }
    public void Unhighlight()
    {
        //Change the color of the coin back to its original color
        myMeshRenderer.material = originalMat;
    }
    public void Collect(PlayerBehaviour player)
    {
        player.ModifyScore(value);
        Destroy(gameObject);
    }
}

