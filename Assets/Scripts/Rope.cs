using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Transform candy;
    public GameObject ropeJoint;
    public float offset = 0.2f;
    [Tooltip("Layer for rope joints - must match the layer used in Cursor script")]
    public LayerMask ropeLayer;
    
    public List<Transform> joints = new();
    
    void Start()
    {
        int jointCount =(int)(Vector3.Distance(transform.position, candy.position) / offset);
        
        Vector3 pos = transform.position;

        for (int i = 0; i < jointCount; i++)
        {
            GameObject joint = Instantiate(ropeJoint, pos, Quaternion.identity);
            pos = Vector3.Lerp(transform.position, candy.position, (float)i / jointCount);
            
            if(i == 0) 
                joint.GetComponent<Joint2D>().connectedBody = GetComponent<Rigidbody2D>();
            else 
                joint.GetComponent<Joint2D>().connectedBody = joints[joints.Count - 1].GetComponent<Rigidbody2D>();
            
            joint.layer = GetLayerFromLayerMask(ropeLayer);
            
            joints.Add(joint.transform);
        }
        
        Joint2D candyJoint = candy.AddComponent<HingeJoint2D>();
        candyJoint.connectedBody = joints[^1].GetComponent<Rigidbody2D>();
    }
    
    private int GetLayerFromLayerMask(LayerMask layerMask)
    {
        int layerNumber = 0;
        int layer = layerMask.value;
        while (layer > 0)
        {
            layer = layer >> 1;
            layerNumber++;
        }
        return layerNumber - 1;
    }
}