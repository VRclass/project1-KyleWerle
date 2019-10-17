using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTimerControl : MonoBehaviour
{

    public Transform seconds;

    private const float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees = 360f / 60f;



    void Update()
    {
        TimeSpan timespan = DateTime.Now.TimeOfDay;
        seconds.localRotation =
                Quaternion.Euler(0f,0f,(float)timespan.TotalSeconds * -secondsToDegrees);
    }
}
