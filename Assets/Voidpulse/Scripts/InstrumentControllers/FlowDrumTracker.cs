using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowDrumTracker : MonoBehaviour
{

    public AudioSource AudioPlayer;

    private float collisionResetTimer = 0.05f;

    private float fullVelocity;

    public void ActivateDrum(float drumHeadVel)
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

        gameObject.GetComponentInChildren<ParticleSystem>().Emit(2);
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
