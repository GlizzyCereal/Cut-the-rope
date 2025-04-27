using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Candy"))
        {
            Destroy(other.gameObject);
            //todo: score
            //todo: animation
            //todo: sound
        }
    }
}
