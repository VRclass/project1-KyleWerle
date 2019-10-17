using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigActivateObject : MonoBehaviour {

	public GameObject OnOffObject;

	private void OnTriggerEnter(Collider Player) {
		OnOffObject.SetActive(true);
	}

	private void OnTriggerExit(Collider Player) {
		OnOffObject.SetActive(false);
	}
}
