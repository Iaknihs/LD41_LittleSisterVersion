using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	public bool useOffsetValues;
	public float rotateSpeed;
	public Transform pivot;

	public float maxViewAngle;
	public float minViewAngle;

	public bool invertY;
	public bool invertX;

	// Use this for initialization
	void Start () {
		if (!useOffsetValues) {
			offset = target.position - transform.position;
		}

		pivot.transform.position = target.transform.position;
		pivot.transform.parent = target.transform;

		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		//Get mouseX & rotate target
		float horizontal = Input.GetAxis ("Mouse X") * rotateSpeed;
		target.Rotate (0, invertX?-horizontal:horizontal, 0);

		//Get mouseY & rotate pivot
		float vertical = Input.GetAxis ("Mouse Y") * rotateSpeed;
		pivot.Rotate (invertY?vertical:-vertical, 0, 0);

		//Limit up/down camera rotation
		if(pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
			pivot.rotation = Quaternion.Euler (maxViewAngle, 0, 0);
		if (pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 360+minViewAngle)
			pivot.rotation = Quaternion.Euler (360+minViewAngle, 0, 0);

		// Move camera based on current target rotation & original offset
		float newYAngle = target.eulerAngles.y;
		float newXAngle = pivot.eulerAngles.x;

		Quaternion rot = Quaternion.Euler (newXAngle,newYAngle,0);
		transform.position = target.position - (rot * offset);

		if (transform.position.y < target.position.y)
			transform.position = new Vector3 (transform.position.x, target.position.y - 0.5f, transform.position.z);

		transform.LookAt(target);

		if(Input.GetMouseButtonDown(0))
			Cursor.lockState = CursorLockMode.Locked;
	}

	void OnMouseDown (){
		
	}
}
