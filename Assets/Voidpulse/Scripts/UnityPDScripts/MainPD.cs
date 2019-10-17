using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPD : MonoBehaviour {

	public string patchName;

	private int patchPD = -1;

    IEnumerator Start() {
        UnityPD.Deinit ();
        yield return new WaitForSeconds (0.3f);

        UnityPD.Init ();
        yield return new WaitForSeconds (0.3f);

		patchPD = UnityPD.OpenPatch( patchName );
	}

	void OnApplicationQuit() {
        UnityPD.Deinit ();
    }

}
