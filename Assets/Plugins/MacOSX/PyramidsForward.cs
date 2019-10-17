using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidsForward : MonoBehaviour {

	public void note(float value)
    {

        Hv_pyramids_AudioLib script = GetComponent<Hv_pyramids_AudioLib>();
        script.SetFloatParameter(Hv_pyramids_AudioLib.Parameter.Note, value);
    }

    public void fm(float value)
    {

				Hv_pyramids_AudioLib script = GetComponent<Hv_pyramids_AudioLib>();
				script.SetFloatParameter(Hv_pyramids_AudioLib.Parameter.Fm, value);
    }

		public void amp(float value)
		{

				Hv_pyramids_AudioLib script = GetComponent<Hv_pyramids_AudioLib>();
				script.SetFloatParameter(Hv_pyramids_AudioLib.Parameter.Amp, value);
		}

		public void decay(float value)
		{

				Hv_pyramids_AudioLib script = GetComponent<Hv_pyramids_AudioLib>();
				script.SetFloatParameter(Hv_pyramids_AudioLib.Parameter.Decay, value);
		}


		public void trigger(bool trigger)
		{
			if(trigger){
				Hv_pyramids_AudioLib script = GetComponent<Hv_pyramids_AudioLib>();
				script.SendEvent(Hv_pyramids_AudioLib.Event.Trigger);
			}

		}


}
