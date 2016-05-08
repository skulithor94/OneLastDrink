﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//Speed of player, this value may change as development continues
	private float speed = 15f;
	private float audioDelay = 0.6f;
	private float audioTimer;
    private Light myLight;

	public AudioClip walk;

	private AudioSource[] source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;

	// Use this for initialization
	void Start () {
        myLight = GameObject.Find("PlayerSpotlight").GetComponentInChildren<Light>();
		source = GetComponents<AudioSource> ();
    }
	
	// Update is called once per frame
	void Update () {

		//Get the coordinate of the mousepointer
		Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		//if the distance between the mouse and the player is greater than 10.1, don't know why that number     
		//the rotation based on the look rotation, it is then changed into a euler angle.
		if (Vector3.Distance (mouse, transform.position) > 10.1f) {
			transform.rotation = Quaternion.LookRotation (Vector3.forward, (mouse - transform.position).normalized);
		}

		//Movement of player
		transform.position += new Vector3 (0, Input.GetAxis ("Vertical"), 0) * speed * Time.deltaTime;
		transform.position += new Vector3 (Input.GetAxis ("Horizontal"), 0, 0) * speed * Time.deltaTime;

		//Audio
		audioTimer += Time.deltaTime;
		WalkSound ();
			
		Flashlight ();
	}

	//Play walking sound if the delay has passed. 
	//There is a fluctuation in volume so that the sound doesn't become to bland.
	void WalkSound(){
		if(audioTimer >= audioDelay && (Input.GetAxis("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0)){
			float vol = Random.Range (volLowRange, volHighRange);
			audioTimer = 0f;
			source[0].PlayOneShot (walk, vol);
		}
	}

	//All flashlight controls, such as raycast from player should go here.
	void Flashlight(){
		if(Input.GetKeyDown(KeyCode.F))
		{
			myLight.enabled = !myLight.enabled;
		}
	}
}
