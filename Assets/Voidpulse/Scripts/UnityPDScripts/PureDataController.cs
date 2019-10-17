using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PureDataController : MonoBehaviour {

	public float curOrientationXValue;
    public float curOrientationYValue;
/* 
	void OnEnable()
	{
		EasyInputHelper.On_Motion += localMotion;
	}

	void OnDestroy()
	{
		EasyInputHelper.On_Motion -= localMotion;
	}

	void localMotion (EasyInputVR.Core.Motion motion)
	{
		curOrientationXValue = motion.currentOrientationEuler.x;
		curOrientationYValue = motion.currentOrientationEuler.y;

		UnityPD.SendFloat("AngleVel", curOrientationXValue);

	}
*/

	public void sendNote (float value) {
		UnityPD.SendFloat( "NoteControl", value );

	}

	public void TriggerControl (float value) {
		UnityPD.SendFloat( "TriggerControl", value );
	}

	public void JetSoundControl (float value) {
		UnityPD.SendFloat( "JetSpeed", value);
	}
}
