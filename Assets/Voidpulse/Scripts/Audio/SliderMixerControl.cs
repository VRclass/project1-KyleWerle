using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Prefabs.Interactions.Controllables;

public class SliderMixerControl : MonoBehaviour
{
    public AudioHelm.AudioHelmClock clockSrc;
    public Text text;
    public string valueName;

    private float startingValue;

    private bool enableControl = false;

    // Start is called before the first frame update
    void Start()
    {
        text.text = valueName;

        StartCoroutine(SetValue(0.5f));
        StartCoroutine(MoveToValue(1f));
    }

    public void BPMcontrol(float value)
    {
        if(enableControl)
        {
            value = value * 300;
            clockSrc.bpm = value;
        }
    }

    IEnumerator SetValue(float time)
    {
        yield return new WaitForSeconds(time);


        startingValue = clockSrc.bpm * 0.00333f;


        gameObject.GetComponent<DirectionalDriveFacade>().TargetValue = startingValue; 
    }

    IEnumerator MoveToValue(float time)
    {
        yield return new WaitForSeconds(time);

        gameObject.GetComponent<DirectionalDriveFacade>().MoveToTargetValue = true;

        yield return new WaitForSeconds(time);

        gameObject.GetComponent<DirectionalDriveFacade>().MoveToTargetValue = false;

        enableControl = true;
    }

}
