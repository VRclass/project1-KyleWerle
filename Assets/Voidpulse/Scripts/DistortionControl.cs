using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DistortionControl : MonoBehaviour
{
    public AudioMixer target;
    public void SetDistortion(float alphaValue)
    {
        target.SetFloat ("distortionVol", alphaValue * 0.90f * Time.deltaTime);
    }
}
