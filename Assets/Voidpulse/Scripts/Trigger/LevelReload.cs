using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReload : MonoBehaviour {
	
	private GameObject viewCover;

	void Start () {
		viewCover = GameObject.Find("/PlayerVoid/Main Camera/ViewCover");

	}

	private void OnTriggerEnter (Collider collider) {
		
		if (collider.tag == "Player") {
			ViewFader animationScript = viewCover.GetComponent<ViewFader>();
			animationScript.FadeToLevel();
			Invoke("ChangeScene", 4.0f);
			
		}
	}

	private void ChangeScene () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
