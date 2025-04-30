using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Transform cursor;

    private bool mouseDown = false;

    void Start()
    {
        cursor.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
            cursor.gameObject.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            cursor.gameObject.SetActive(false);
        }

        if (mouseDown)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = ScreenToWorldPoint(mousePos);
            cursor.position = worldPos;
        }
    }

    Vector3 ScreenToWorldPoint(Vector3 screenPos)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        return worldPos;
    }
}
