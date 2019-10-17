using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour {

	public GameObject ViewCover;

	public int LevelToChange = 0;
	private void OnTriggerEnter (Collider other) {
		Invoke("ChangeScene", 4.0f);
		ViewFader otherScript = ViewCover.GetComponent<ViewFader>();
		otherScript.FadeToLevel();
		//Debug.Log("On Trigger");
	}

	private void ChangeScene () {
		SceneManager.LoadScene(LevelToChange);
	}

}
