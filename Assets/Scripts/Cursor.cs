using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var joint = other.gameObject.GetComponent<Joint2D>();
        if(joint != null) Destroy(joint);
    }
}
