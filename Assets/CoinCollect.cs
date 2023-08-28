using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public int coins=0;
    public GameManager gameManager;

    void Start()
    {
        gameManager= FindObjectOfType<GameManager>();
    }
    
    public void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "coin")
        {
            Debug.Log("Collided");
            other.gameObject.SetActive(false);
            coins+=1;

            gameManager.UpdateScore(coins);

        }
        
    }
}
