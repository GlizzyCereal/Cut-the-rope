using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    [Tooltip("Tag for star objects that can be collected")]
    public string starTag = "Star";
    
    [Tooltip("Number of stars collected in this level")]
    public int starsCollected = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(starTag))
        {
            starsCollected++;
            
            Destroy(collision.gameObject);
            
            UIManager.instance.starGet(starsCollected);
            
            Debug.Log("Star collected! Total: " + starsCollected);
        }
    }

    public void Die()
    {
        UIManager.instance.ShowEndGame(starsCollected);
        
        GetComponent<Rigidbody2D>().simulated = false;
    }
}