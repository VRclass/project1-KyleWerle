using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumHeadCastTrigger : MonoBehaviour
{

    public GameObject HapticInteractor;

    private Vector3 prevPos; 
    private Vector3 newPos; 

    int layerMask;


    void Start()
    {
        //mask for physics interactions
        layerMask = LayerMask.GetMask("Drum");
        prevPos = transform.position;
        newPos = transform.position;
    }

    void FixedUpdate()
    {
        newPos = transform.position;

        //linecast from previous location to current location
        RaycastHit lineHit;
        //Debug.DrawLine(prevPos, newPos, Color.white, 2f, false);
        if (Physics.Linecast(prevPos, newPos, out lineHit, layerMask, QueryTriggerInteraction.Collide))
        {
            //obtain magnitude from Create Velocity Script
            float drumHeadVel = this.gameObject.GetComponent<CreateVelocity>().ObjVelocity.magnitude;
            //send velocity to Activate Drum
            lineHit.collider.gameObject.GetComponent<VelocityTracker>().ActivateDrum(drumHeadVel);
        }

        prevPos = newPos;
    }

    IEnumerator HapticControl(float time, float intensity)
    {
        yield return new WaitForSeconds(time);
    }
}
