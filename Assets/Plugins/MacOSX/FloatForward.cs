using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatForward : MonoBehaviour {

	public void freq(float value)
    {
        
        Hv_helloWorld_AudioLib script = GetComponent<Hv_helloWorld_AudioLib>();
        script.SetFloatParameter(Hv_helloWorld_AudioLib.Parameter.Freq, value);
    }

    public void amp(float value)
    {

        Hv_helloWorld_AudioLib script = GetComponent<Hv_helloWorld_AudioLib>();
        script.SetFloatParameter(Hv_helloWorld_AudioLib.Parameter.Level, value);
    }

	public void playNote(bool play)
	{
        Hv_helloWorld_AudioLib script = GetComponent<Hv_helloWorld_AudioLib>();
        if (play)
        {
            script.SetFloatParameter(Hv_helloWorld_AudioLib.Parameter.Level, 0.5f); 
        } else
        {
            script.SetFloatParameter(Hv_helloWorld_AudioLib.Parameter.Level, 0f);   
        }
	}


}
