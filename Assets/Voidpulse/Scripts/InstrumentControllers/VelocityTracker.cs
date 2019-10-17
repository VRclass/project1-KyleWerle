using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityTracker : MonoBehaviour
{

    public AudioSource AudioPlayer;

    public ParticleSystem MultiParticle;
    public ParticleSystem SingleParticle;

    public bool FlowDrum = false;

    private float collisionResetTimer = 0.05f;

    private float fullVelocity;

    public void ActivateDrum(float drumHeadVel)
    {
        if (FlowDrum)
        {
            FlowPadActivate(drumHeadVel);
        } else {
            DrumPadActivate(drumHeadVel);
        }

    }

    void DrumPadActivate(float drumHeadVel)
    {
        fullVelocity = drumHeadVel + this.gameObject.GetComponent<CreateVelocity>().ObjVelocity.magnitude;
        //print("Collider : " + inRay.collider.GetComponent<CreateVelocity>().ObjVelocity.magnitude);
        //print("This : " + this.gameObject.GetComponent<CreateVelocity>().ObjVelocity.magnitude);

        fullVelocity = Mathf.Clamp(fullVelocity, 0f, 4f);

        this.gameObject.GetComponent<AddForce>().DownForce((fullVelocity * 0.75f) + 1.5f);

        ChangeColor();

        HitParticles();
        
        fullVelocity = fullVelocity / 4f;
        AudioPlayer.volume = Mathf.Clamp(fullVelocity, 0.04f, 1f);
        //print(fullVelocity);
        AudioPlayer.Play();

        //begin coroutine
        StartCoroutine(ResetCollision(collisionResetTimer));

    }

    void FlowPadActivate(float drumHeadVel)
    {
        fullVelocity = drumHeadVel;

        fullVelocity = Mathf.Clamp(fullVelocity, 0f, 4f);

        StartCoroutine(EnableRender(collisionResetTimer));

        ChangeColor();

        HitParticles();
        
        fullVelocity = fullVelocity / 4f;
        AudioPlayer.volume = Mathf.Clamp(fullVelocity, 0.04f, 1f);
        //print(fullVelocity);
        AudioPlayer.Play();

        //begin coroutine
        StartCoroutine(ResetCollision(collisionResetTimer));
    }

    void ChangeColor()
    {
        this.gameObject.GetComponent<ChangeColor>().increaseColorBrightness();

        StartCoroutine(ResetColor(collisionResetTimer));
    }

    void HitParticles()
    {
        //this.gameObject.GetComponent<ParticleSystem>().Emit(2);

        MultiParticle.Emit(2);
        SingleParticle.Emit(1);

        //gameObject.GetComponentInChildren<ParticleSystem>().Emit(2);

    }

    //co-routine for delayed time functions

    IEnumerator ResetColor(float time)
    {
        
        yield return new WaitForSeconds(time);

        this.gameObject.GetComponent<ChangeColor>().changeColorBack();

    }

    IEnumerator ResetCollision(float time)
    {
        this.gameObject.layer = 9;

        yield return new WaitForSeconds(time);

        //code to execute after wait time
        this.gameObject.layer = 8;

        //print("Reset Gameobject layer");
    }

    IEnumerator EnableRender(float time)
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;

        yield return new WaitForSeconds(time);

        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
