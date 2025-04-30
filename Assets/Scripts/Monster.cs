using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Tooltip("Tag of the candy object that can be eaten")]
    public string candyTag = "Candy";
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(candyTag))
        {
            UIManager.instance.ShowEndGame(3); // Show end game UI with 0 stars
            Destroy(collision.gameObject);
            
            Debug.Log("Candy eaten!");
        }
    }
}