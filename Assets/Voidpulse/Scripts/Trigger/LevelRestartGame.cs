using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRestartGame : MonoBehaviour {

	private GameObject ViewCover;
	private GameObject SceneController;

	void Start () {
		//	setup game objects in hierarchy
		ViewCover = GameObject.Find("/PlayerVoid/Main Camera/ViewCover");
		SceneController = GameObject.Find("/SceneController");
		
	}

	private void OnTriggerEnter (Collider collider) {

		if (collider.tag == "Player") {
			//	setup animation script
			ViewFader animationScript = ViewCover.GetComponent<ViewFader>();
			//	run FadeToLevel animation
			animationScript.FadeToLevel();

			//	setup scene script from scene controller game object
			SceneController sceneScript = SceneController.GetComponent<SceneController>();
			//	run Restart function from SceneController script
			sceneScript.RestartExperience();

			Debug.Log("Trigger Complete : RESTART");
			
		}
	}
}
