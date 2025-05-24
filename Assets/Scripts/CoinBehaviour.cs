using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{ 
    public int value = 10;

    public void Collect(PlayerBehaviour player)
    {
        player.ModifyScore(value);
        Destroy(gameObject);
    }
}

