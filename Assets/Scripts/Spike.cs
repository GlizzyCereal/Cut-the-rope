using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [Tooltip("Tag for candy object")]
    public string candyTag = "Candy";
    public GameObject candyVFX;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(candyTag))
        {
            collision.gameObject.GetComponent<Candy>().Die();
            Destroy(collision.gameObject);
            Instantiate(candyVFX, collision.transform.position, Quaternion.identity);
            //TODO: Add game over logic here
            Debug.Log("Candy hit the spike! Game Over!");
        }
    }
}
