using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	private GameObject PlayerSpawner;

	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}

	public void MoveToSpawner () {
		PlayerSpawner = GameObject.Find("/PlayerSpawner");
		transform.position = PlayerSpawner.transform.position;
	}


}
