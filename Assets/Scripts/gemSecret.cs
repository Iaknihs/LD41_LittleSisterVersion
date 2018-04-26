using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemSecret : MonoBehaviour {

	public GameObject controller;
	public int amountNeeded;
	public GameObject toActivate;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (controller.GetComponent<Score> ().gems > amountNeeded) {
			toActivate.SetActive (true);
			Destroy (gameObject);
		}
	}
}
