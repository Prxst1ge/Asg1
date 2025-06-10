using UnityEngine;

public class GiftBox : MonoBehaviour
{

    public GameObject Coin;

    [SerializeField]
    int numberOfCoins = 1;

    [SerializeField]
    Transform spawnPoint;

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object hitting this is a projectile
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("balls");
            GameObject newCoin = Instantiate(Coin, spawnPoint.position , spawnPoint.rotation);
            Destroy(collision.gameObject); 
            Destroy(gameObject);           
        }
    }
}
