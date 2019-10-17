using System;
using System.Collections;
using UnityEngine;
//using EasyInputVR.Core;

public class AxisRetriever : MonoBehaviour {

        public float curAngVelXValue;
        public float curAngVelYValue;
        public float curAngVelZValue;
/* 
        void OnEnable()
        {
            EasyInputHelper.On_Motion += localMotion;
        }

        void OnDestroy()
        {
            EasyInputHelper.On_Motion -= localMotion;
        }
        // Update is called once per frame
        void Update()
        {
        }

        void localMotion (EasyInputVR.Core.Motion motion)
        {
            curAngVelXValue = motion.currentAngVel.x;
            curAngVelYValue = motion.currentAngVel.y;
            curAngVelZValue = motion.currentAngVel.z;
            
        }

		public void TriggerControl (float value) {
		UnityPD.SendFloat( "TriggerControl", value );
		}
*/
}
