using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Prefabs.Interactions.Controllables;

public class SliderController : MonoBehaviour
{

    public AudioHelm.HelmController helmController;

    public AudioHelm.Param helmVariable = AudioHelm.Param.kVolume;

    public Text text;
    public string valueName;
    public bool ValueControlMode = false;
    public float minValue = 0;
    public float maxValue = 1;
    
    private float startingValue;

    private bool enableControl = false;

    void Start()
    {
        text.text = valueName;

        StartCoroutine(SetValue(0.5f));
        StartCoroutine(MoveToValue(1f));
    }

    public void SynthSliderControl(float value)
    {

        if (enableControl)
        {
            if(ValueControlMode){
                value = value * maxValue;
                value = value + minValue;
                helmController.SetParameterValue(helmVariable, value);
            } else {
                helmController.SetParameterPercent(helmVariable, value);
            }
            
        }

    }

    IEnumerator SetValue(float time)
    {
        yield return new WaitForSeconds(time);

        if(ValueControlMode){
            startingValue = helmController.GetParameterValue(helmVariable);
        } else {
            startingValue = helmController.GetParameterPercent(helmVariable);


        }
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
