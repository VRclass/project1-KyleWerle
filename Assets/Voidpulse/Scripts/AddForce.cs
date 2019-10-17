using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public float force;
    public Rigidbody rb;
    public bool UseStaticForce = false;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    //relative impulse y force to rigidbody
    public void DownForce(float forceAmount) {

        if(UseStaticForce)
        {
            rb.AddRelativeForce(0, force, 0, ForceMode.Impulse);
        } else {
            rb.AddRelativeForce(0, forceAmount, 0, ForceMode.Impulse);
        }
        
    }

    public void XaxisForce(float forceAmount)
    {
        rb.AddRelativeForce(forceAmount, 0, 0 , ForceMode.Impulse);
    }

    public void ZaxisForce(float forceAmount)
    {
        rb.AddRelativeForce(0, 0, forceAmount, ForceMode.Impulse);
    }


    //global impulse y force to rigic body
    public void WorldVerticalForce() {
        rb.AddForce(0, force, 0, ForceMode.Impulse);
    }
}
