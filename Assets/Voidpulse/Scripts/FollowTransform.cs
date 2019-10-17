using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    public GameObject followThisObject;
    public float speed = 10f;

    public bool followRotation = true;

    private Vector3 currentPosition;

    void FixedUpdate () {

        currentPosition = followThisObject.transform.position;

        if (currentPosition != transform.position){
            //smoothly follow selected object's positions and rotation
            transform.position = Vector3.Lerp(transform.position, currentPosition, Time.deltaTime * speed);
            
            if (followRotation){
                transform.rotation = Quaternion.Lerp(transform.rotation, followThisObject.transform.rotation, Time.deltaTime * speed);
            }

        }
    }

}
