/*
using System.Collections;
using System.Collections.Generic;
using EasyInputVR.Core;
using UnityEngine;

public class PlayerMovement: MonoBehaviour {

    public float RotateSpeed = 30f;
    public float MovementSpeed = 40f;

    Rigidbody rb;
    Vector3 m_EulerAngleVelocity;

    void Start()
    {
        //Set the axis the Rigidbody rotates in (100 in the y axis)
        m_EulerAngleVelocity = new Vector3(0, RotateSpeed, 0);

        rb = GetComponent<Rigidbody>();
    }

    public void goLeft(InputTouch control)
    {
///////
        if (control > 0)
        {
            //rotate
            Quaternion deltaRotation = Quaternion.Euler(-m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);

        }
///////

    }

///////
    public void goRight(InputTouch control)
    {
        if (control > 0)
        {
            //rotate
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
            //transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);

        }
    }
/////////
    public void goForward(InputTouch touch)
    {

      float control = touch.currentTouchPosition.x;

            //rb.AddRelativeForce(Vector3.forward * MovementSpeed * Time.deltaTime * control * 50, ForceMode.Acceleration);

    }

//////////
    public void goBack(InputTouch touch)
    {
      float control = touch;
        if (control > 0)
        {
            rb.AddRelativeForce(Vector3.back * MovementSpeed * Time.deltaTime * control * 50, ForceMode.Acceleration);
        }

    }
////////



}
*/
