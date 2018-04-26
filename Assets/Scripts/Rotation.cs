using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	public float rotationSpeedX;
	public float rotationSpeedY;
	public float rotationSpeedZ;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate ((new Vector3(rotationSpeedX,rotationSpeedY,rotationSpeedZ))*Time.deltaTime);
	}
}
