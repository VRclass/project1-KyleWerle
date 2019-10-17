using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeqButton : MonoBehaviour
{
    public AudioHelm.Sequencer Sequencer;
    public int Note;
    public int StepNumber;

    private bool StepToggle = false;

    public void ToggleStep()
    {
        if(StepToggle)
        {
            Sequencer.RemoveNotesInRange(Note, StepNumber, StepNumber + 1);
            StepToggle = false;
        } else {
            Sequencer.AddNote(Note, StepNumber, StepNumber + 1);
            StepToggle = true;
        }
    }
}
