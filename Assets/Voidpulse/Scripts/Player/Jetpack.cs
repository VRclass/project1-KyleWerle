
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour {
	public GameObject JetpackView;
	public float JetSpeed = 30f;
	public float EnergyUseMultiplier = 2f;
	public float EnergyRechargeMultiplier = 0.7f;
	float MaxEnergy = 1.3f;
	public float Energy = 0.1f;
	float ObjectScale = 0.1f;

	public static bool JetMenu = false;

	Rigidbody rb;
	Vector3 JetpackVel;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		JetpackVel = new Vector3(0, JetSpeed, 0);
	}

	void Update() {

		if (JetMenu) {
			JetpackView.transform.localScale = new Vector3(0.015f,0.014f,0.01f);
			Energy = 0;
		} else {

			if (Energy < MaxEnergy) {
				Energy += Time.deltaTime * EnergyRechargeMultiplier;
				ObjectScale = Energy * 0.1f;
				JetpackView.transform.localScale = new Vector3(0.015f,0.014f,ObjectScale + 0.01f);

			}

		}

		//rb.AddRelativeForce(JetpackVel * Time.deltaTime * 2, ForceMode.Acceleration); //Acceleration
	}

	public void JetpackEnable(bool Flying) {
		if (!JetMenu) {
			if (Flying) {
				Energy -= Time.deltaTime * EnergyUseMultiplier;
				ObjectScale = Energy * 0.1f;
				JetpackView.transform.localScale = new Vector3(0.015f,0.014f,ObjectScale + 0.05f);

				if (Energy <= 0) {
					Energy = -0.01f;
					UnityPD.SendFloat( "JetSpeed", 0.12f);

				} else {
					rb.AddRelativeForce(JetpackVel * Time.deltaTime * 50, ForceMode.Acceleration); //Acceleration
					UnityPD.SendFloat( "JetSpeed", 0.47f);
				}
			}
		} else {
			UnityPD.SendFloat( "JetSpeed", 0.01f);
		}

	}

}
