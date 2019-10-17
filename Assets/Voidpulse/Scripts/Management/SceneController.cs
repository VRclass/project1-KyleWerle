using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	//public GameObject LevelTrigger;
	public int maxScenes = 3;
	private List<int> scenesList = new List<int>();
	private List<int> usedScenesList = new List<int>();
	private int currentSceneCount = 0;
	private int sceneSelector;
	
	private GameObject UnityPD;
	private GameObject PlayerVoid;


	void Start () {
		DontDestroyOnLoad (transform.gameObject);

		UnityPD = GameObject.Find("/UnityPD");
		PlayerVoid = GameObject.Find("/PlayerVoid");

		UnityEngine.Random.InitState((int)System.Environment.TickCount);

		Debug.Log((int)System.Environment.TickCount);
		
		scenesList.Add(1);
		scenesList.Add(2);
		scenesList.Add(3);
		scenesList.Add(4);
		scenesList.Add(5);
		scenesList.Add(6);
		scenesList.Add(7);
		scenesList.Add(8);
		scenesList.Add(9);
		scenesList.Add(10);
		scenesList.Add(11);
		scenesList.Add(12);
	}

	public void NextScene () {
		//Debug.Log("Next Scene Function Starts");

		if(currentSceneCount < maxScenes) {

			currentSceneCount++;
			sceneSelector = UnityEngine.Random.Range(1,scenesList.Count + 1);

			while (usedScenesList.Contains(sceneSelector)) {
				sceneSelector = UnityEngine.Random.Range(1,scenesList.Count + 1); 
			}

			usedScenesList.Add(sceneSelector);
			Debug.Log(sceneSelector);
			Invoke("ChangeScene", 4.0f);
			
		} else {

			Invoke("EndExperience", 4.0f);

		}

	}

	public void FullWalkthrough () {

		maxScenes = scenesList.Count;

		NextScene();

	}

	public void DebugSceneLoader () {
		Invoke("DebugScene", 4.0f);
	}

	public void DebugScene () {
		SceneManager.LoadScene(1);
	}

	private void ChangeScene () {
		Debug.Log(sceneSelector);
		SceneManager.LoadScene(sceneSelector);
	}

	public void RestartExperience () {

		Invoke("Restart", 4.0f);
	}
	
	private void Restart () {
		Jetpack.JetMenu = false;

		currentSceneCount = 0;
		sceneSelector = 0;

		usedScenesList.Clear();

		SceneManager.LoadScene(0);
		Debug.Log(sceneSelector);
		Destroy (UnityPD);
		Destroy (PlayerVoid);
		Destroy (gameObject);

	}

	public void EndExperience () {

		SceneManager.LoadScene("endScene");
		
	}

}

