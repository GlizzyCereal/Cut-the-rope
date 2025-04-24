using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Transform candy;
    public GameObject ropeJoint;
    public float offset = 0.3f;

    public List<Transform> joints = new();
    
    void Start()
    {
        int count = (int)(Vector3.Distance(candy.position, transform.position) / offset);
        
        Vector3 position = transform.position;

        for (int i = 0; i < count; i++)
        {
            GameObject joint = Instantiate(ropeJoint, position, Quaternion.identity, transform);
            
            position = Vector3.Lerp(transform.position, candy.position, (float)i / count);
            
            //first rope part is connected to the pin
            if (i == 0)
            {
                joint.GetComponent<Joint2D>().connectedBody = GetComponent<Rigidbody2D>();
            }
            //connect rope to last rope element
            else
            {
                joint.GetComponent<Joint2D>().connectedBody = joints[i - 1].gameObject.GetComponent<Rigidbody2D>();
            }
            
            joints.Add(joint.transform);
        }
        
        //connect last rope part to candy
        candy.GetComponent<HingeJoint2D>().connectedBody = joints[joints.Count - 1].gameObject.GetComponent<Rigidbody2D>();
    }

    
}
