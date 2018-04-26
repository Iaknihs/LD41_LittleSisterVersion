using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStart : MonoBehaviour {

	public AudioClip sound;

	public AudioSource musicSource;

	// Use this for initialization
	void Start () {
		musicSource.clip = sound;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Playsound(){
		musicSource.Play ();
	}
}
