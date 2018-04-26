using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	public GameObject audioSource;
	public AudioClip sound;

	public int itemID;
	public Transform collector;
	public GameObject controller;
	public float collectionDistance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (collector.position, transform.position) < collectionDistance) {
			audioSource.GetComponent<MusicStart> ().musicSource.clip = sound;
			audioSource.GetComponent<MusicStart> ().Playsound();
			controller.GetComponent<Score>().addCollected(itemID);
			Destroy (gameObject);
		}
	}
}
