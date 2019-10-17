using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class helloPD : MonoBehaviour {

	public string patchName;

	private int patchPD = -1;


    IEnumerator Start() {
        yield return new WaitForSeconds (1f);

        UnityPD.Init ();
        yield return new WaitForSeconds (2f);

		patchPD = UnityPD.OpenPatch( patchName );
	}

	void OnApplicationQuit() {
        UnityPD.Deinit ();
    }

	void Update () {
		
	}

	public void sendBang () {
		UnityPD.SendBang( "noteOn" );

	}
}
