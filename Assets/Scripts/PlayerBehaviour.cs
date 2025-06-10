using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int score = 0;
    int health = 100;
    bool canInteract = false;
    CoinBehaviour currentCoin;
    DoorBehaviour currentDoor;

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    float fireStrength = 0f;

    [SerializeField]
    float interactionDistance = 5f;

    void Update()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out hitInfo))
        {
            //Debug.Log("Raycast hit: " + hitInfo.collider.gameObject.name);
            if (hitInfo.collider.gameObject.CompareTag("Collectible"))
            {

                if (currentCoin != null)
                {
                    currentCoin.Unhighlight();
                }
                canInteract = true;
                currentCoin = hitInfo.collider.gameObject.GetComponent<CoinBehaviour>();
                currentCoin.Highlight(); //highlight the coin
                    
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Debug.Log("Player is looking at " + other.gameObject.name);
            currentCoin = other.gameObject.GetComponent<CoinBehaviour>();
            canInteract = true;
            currentCoin = other.GetComponent<CoinBehaviour>();
            currentCoin.Highlight(); //highlight the coin
        }
        else if (other.CompareTag("Door"))
        {
            canInteract = true;
            currentDoor = other.GetComponent<DoorBehaviour>();
        }
    }
    void OnInteract()
    {
        if (canInteract)
        {
            Debug.Log("Player interacted with object");

            if (currentCoin != null)
            {
                currentCoin.Collect(this);
                currentCoin = null;
            }

            canInteract = false;
        }
        else if (currentDoor != null)
        {
            Debug.Log("Interacting with door");
            currentDoor.Interact();
        }
        else
        {
            Debug.Log("No object to interact with");
        }


    }
    void OnFire()
    {
        GameObject newProjectile = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        Vector3 fireForce = spawnPoint.forward * fireStrength;
        newProjectile.GetComponent<Rigidbody>().AddForce(fireForce);
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {

            canInteract = false;
        }
    }
    public void ModifyScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }
    
}
