using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollisionPlayer : MonoBehaviour
{

    public AudioClip AudioClip;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource> ().playOnAwake = false;
        GetComponent<AudioSource> ().clip = AudioClip;
    }

    void OnCollisionEnter ()  //Plays Sound Whenever collision detected
    {
        GetComponent<AudioSource> ().Play ();
    }

    // Make sure that deathzone has a collider, box, or mesh.. ect..,
    // Make sure to turn "off" collider trigger for your deathzone Area;
    // Make sure That anything that collides into deathzone, is rigidbody;
}
