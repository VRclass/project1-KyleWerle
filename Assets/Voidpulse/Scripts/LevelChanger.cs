using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

	private GameObject ViewCover;
	private GameObject SceneController;

	void Start () {
		//	setup game objects in hierarchy
		ViewCover = GameObject.Find("/PlayerVoid/Main Camera/ViewCover");
		SceneController = GameObject.Find("/SceneController");
	}

	public void ChangeToHub()
	{
		//	setup animation script
		ViewFader animationScript = ViewCover.GetComponent<ViewFader>();
		//	run FadeToLevel animation
		animationScript.FadeToLevel();

		//	setup scene script from scene controller game object
		SceneController sceneScript = SceneController.GetComponent<SceneController>();
		//	run NextScene function from SceneController script
		sceneScript.RestartExperience();
	}

}
