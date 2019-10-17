using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EquipRenderCamera : MonoBehaviour {

	private GameObject PlayerVoidCamera;

	// Use this for initialization
	void Start () {
		SceneManager.activeSceneChanged += ChangedActiveScene;

		PlayerVoidCamera = GameObject.Find("/PlayerVoid/Main Camera");

		this.transform.parent = PlayerVoidCamera.transform;
		transform.localRotation = Quaternion.Euler(0, 0, 0);
		transform.localPosition = new Vector3(0, 0, -0.5f);
	}

	void ChangedActiveScene (Scene current, Scene next) {
		Destroy(gameObject);

	}
}
