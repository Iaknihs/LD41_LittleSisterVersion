using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	public Transform teleportee;
	public Transform teleportoo;
	public float activateDistance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (teleportee.position, transform.position) < activateDistance) {
			teleportee.position = teleportoo.position;
		}
	}
}
