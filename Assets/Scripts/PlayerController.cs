using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public AudioClip sound;

    public float moveSpeed;
	public float jumpForce;

    public CharacterController controller;
	public Vector3 moveDirection;
	public float gravityScale;
	public float slopeLimit;
	public float slideFriction;

	public float ghostJumpTime;
	private float jumpableTimer;
	private bool isGrounded;
	private Vector3 hitNormal;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		moveDirection.x = 0;
		moveDirection.z = 0;

		if (isGrounded)
			jumpableTimer = 0f;
		else
			jumpableTimer += Time.deltaTime;

		float ytemp = moveDirection.y;
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= moveSpeed;
		moveDirection.y = ytemp;

		if(isGrounded)
			moveDirection.y = 0f;

		if(jumpableTimer<ghostJumpTime){
			if (Input.GetButtonDown("Jump")) {
				GetComponent<MusicStart> ().musicSource.clip = sound;
				GetComponent<MusicStart> ().Playsound();
				moveDirection.y = jumpForce;
				jumpableTimer = ghostJumpTime;
			}
		}

		moveDirection.y += (Physics.gravity.y*gravityScale*Time.deltaTime);



		if (!isGrounded) {
			moveDirection.x += (1f - hitNormal.y) * hitNormal.x * (1f - slideFriction)*6;
			moveDirection.z += (1f - hitNormal.y) * hitNormal.z * (1f - slideFriction)*6;
		}

		hitNormal = new Vector3 (0,0,0);
		controller.Move(moveDirection*Time.deltaTime);
		isGrounded = (Vector3.Angle (Vector3.up, hitNormal) <= slopeLimit);


	}

	void OnControllerColliderHit (ControllerColliderHit hit){
		hitNormal = hit.normal;
	}
}
