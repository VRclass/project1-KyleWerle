using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrumStepSequencer : MonoBehaviour
{
    public AudioHelm.SampleSequencer Sequencer;
    public GameObject SeqButton;
    public GameObject[] SequencerSteps;

    public GameObject StepPosition;
    private bool rootSelect = true;
    private Vector3 rootStepPosition;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < SequencerSteps.Length; i++)
        {
            Vector3 localPosition = transform.TransformPoint(Vector3.right * i * 0.075f);
            Quaternion parentRotation = gameObject.transform.rotation;
            GameObject clone = (GameObject)Instantiate(SeqButton, localPosition, parentRotation, gameObject.transform);

            SequencerSteps[i] = clone;
            
            SequencerSteps[i].GetComponent<SeqButton>().Sequencer = Sequencer;
            SequencerSteps[i].GetComponent<SeqButton>().Note = 60;
            SequencerSteps[i].GetComponent<SeqButton>().StepNumber = i;
        }
    }

    public void SetStepPosition()
    {
        if(rootSelect)
        {
            rootStepPosition = StepPosition.transform.localPosition;
            rootSelect = false;
        }
        
        int step = Sequencer.currentIndex;

        if(step == 15)
        {
            StepPosition.transform.localPosition = rootStepPosition;
        } else {
            StepPosition.transform.localPosition = rootStepPosition + new Vector3((step + 1) * 0.075f, 0, 0);
        }

    }
    
}
