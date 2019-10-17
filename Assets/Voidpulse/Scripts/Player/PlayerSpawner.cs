using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	private GameObject PlayerVoid;
	private GameObject ViewCover;

	void Start () {
		//	setup game objects in hierarchy
		PlayerVoid = GameObject.Find("/PlayerVoid");
		ViewCover = GameObject.Find("/PlayerVoid/Main Camera/ViewCover");

		//	setup player move script
		PlayerManager moveScript = PlayerVoid.GetComponent<PlayerManager>();
		//	run MoveToSpawner script
		moveScript.MoveToSpawner();

		//	setup animation script
		ViewFader animationScript = ViewCover.GetComponent<ViewFader>();
		//	run FadeInLevel animation
		animationScript.FadeInLevel();
	}


}
