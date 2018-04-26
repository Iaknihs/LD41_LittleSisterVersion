using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemDoor : MonoBehaviour {

	public GameObject controller;
	public int amountNeeded;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.GetComponent<Score> ().gems > amountNeeded)
			Destroy (gameObject);
	}
}
