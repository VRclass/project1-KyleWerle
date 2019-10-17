using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentColorShifter : MonoBehaviour
{
    public void InstrumentColorCycle(float frequencyInput){
            Global.ColorShifter = frequencyInput;
    }
}
