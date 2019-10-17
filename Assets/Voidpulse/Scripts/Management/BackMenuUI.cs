using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMenuUI : MonoBehaviour {

	public GameObject Menu;

	private GameObject ViewCover;
	private GameObject SceneController;

	private bool MenuToggle = false;

	// Use this for initialization
	void Start () {
		Jetpack.JetMenu = false;
		//	setup game objects in hierarchy
		ViewCover = GameObject.Find("/PlayerVoid/Main Camera/ViewCover");
		SceneController = GameObject.Find("/SceneController");
		
	}
	
	public void BackMenuToggle () {
		MenuToggle = !MenuToggle;

		if (MenuToggle) {
			//	enables menu and disable jetpack
			Menu.SetActive(true);
			Jetpack.JetMenu = true;

		} else {
			//	disable menu and enable jetpack
			Menu.SetActive(false);
			Jetpack.JetMenu = false;

		}

		
	}

	public void RestartGame () {
		//	setup animation script
		ViewFader animationScript = ViewCover.GetComponent<ViewFader>();
		//	run FadeToLevel animation
		animationScript.FadeToLevel();

		//	setup scene script from scene controller game object
		SceneController sceneScript = SceneController.GetComponent<SceneController>();
		//	run NextScene function from SceneController script
		sceneScript.RestartExperience();

		Debug.Log("On Trigger Complete : RESTART MENU");
	}

	public void FadeToQuit () {
		//	setup animation script
		ViewFader animationScript = ViewCover.GetComponent<ViewFader>();
		//	run FadeToLevel animation
		animationScript.FadeToLevel();

		Invoke("QuitGame", 4.0f);

	}

	private void QuitGame () {
		Application.Quit();
	}
}
