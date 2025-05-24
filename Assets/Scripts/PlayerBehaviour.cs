using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int score = 0;
    int health = 100;
    bool canInteract = false;
    CoinBehaviour currentCoin;

    void OnInteract()
    {
        if(canInteract)
        {
            Debug.Log("Player interacted with object");
            currentCoin.Collect(this);
            currentCoin = null;
            canInteract = false;
        }
        else
        {
            Debug.Log("No object to interact with");
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectible"))
        {
            Debug.Log("Player is looking at " + other.gameObject.name);
            currentCoin = other.gameObject.GetComponent<CoinBehaviour>();
            canInteract = true;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Collectible"))
        {
            currentCoin = null;
            canInteract = false;
        }
    }
    public void ModifyScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }
}
