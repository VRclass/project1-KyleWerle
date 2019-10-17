using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateVelocity : MonoBehaviour
{

    //public bool DEBUG = false;
    private Vector3 prevPos; 
    private Vector3 newPos; 
    public Vector3 ObjVelocity;

    void Start()
    {
        prevPos = transform.position;
        newPos = transform.position;
    }
 
    void FixedUpdate()
    {
        newPos = transform.position;  //each frame track the new position
        ObjVelocity = (newPos - prevPos) / Time.fixedDeltaTime;  // velocity = dist/time  
        prevPos = newPos;  //update position for next frame calculation
    }

    // access with ObjVelocity.magnitude
    // collider.GetComponent<CreateVelocity>().ObjVelocity.magnitude
}
