using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Prefabs.Interactions.Controllables;

public class KnobController : MonoBehaviour
{

    public AudioHelm.HelmController helmController;

    public AudioHelm.Param helmVariable = AudioHelm.Param.kVolume;

    public Text text;
    public string valueName;
    private float startingValue;

    private bool enableControl = false;

    void Start()
    {
        text.text = valueName;
        //text.text = helmVariable.ToString();

        StartCoroutine(SetValue(1f));
        StartCoroutine(MoveToValue(3f));
    }

    public void SynthSliderControl(float value)
    {

        if (enableControl)
        {
            helmController.SetParameterPercent(helmVariable, value);
        }

    }

    IEnumerator SetValue(float time)
    {
        yield return new WaitForSeconds(time);

        startingValue = helmController.GetParameterPercent(helmVariable);

        gameObject.GetComponent<RotationalDriveFacade>().TargetValue = startingValue;

    }

    IEnumerator MoveToValue(float time)
    {
        yield return new WaitForSeconds(time);

        gameObject.GetComponent<RotationalDriveFacade>().MoveToTargetValue = true;

        yield return new WaitForSeconds(time);

        gameObject.GetComponent<RotationalDriveFacade>().MoveToTargetValue = false;

        enableControl = true;
    }

}
