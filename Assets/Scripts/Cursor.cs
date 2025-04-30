using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Camera mainCamera;
    
    [Header("Cutting Settings")]
    public float cutRadius = 0.2f;
    public LayerMask ropeLayer; 
    
    void Start()
    {
        mainCamera = Camera.main;
        UnityEngine.Cursor.visible = false;
    }
    
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0f; 
        transform.position = worldPosition;
        
        if (Input.GetMouseButton(0))
        {
            CutRopes();
        }
    }
    
    void CutRopes()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, cutRadius, ropeLayer);
        
        foreach (var hitCollider in hitColliders)
        {
            Transform jointTransform = hitCollider.transform;
            Rope rope = FindRopeForJoint(jointTransform);
            
            if (rope != null)
            {
                BreakRopeAt(rope, jointTransform);
            }
        }
    }
    
    private Rope FindRopeForJoint(Transform jointTransform)
    {
        Rope[] allRopes = FindObjectsOfType<Rope>();
        foreach (var rope in allRopes)
        {
            if (rope.joints.Contains(jointTransform))
            {
                return rope;
            }
        }
        return null;
    }
    
    private void BreakRopeAt(Rope rope, Transform jointTransform)
    {
        int jointIndex = rope.joints.IndexOf(jointTransform);
        if (jointIndex < 0) return;
        
        Joint2D joint = jointTransform.GetComponent<Joint2D>();
        if (joint != null)
        {
            Destroy(joint);
        }
        
        if (jointIndex == rope.joints.Count - 1)
        {
            Joint2D[] candyJoints = rope.candy.GetComponents<Joint2D>();
            foreach (var candyJoint in candyJoints)
            {
                if (candyJoint.connectedBody == jointTransform.GetComponent<Rigidbody2D>())
                {
                    Destroy(candyJoint);
                    break;
                }
            }
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, cutRadius);
    }
}