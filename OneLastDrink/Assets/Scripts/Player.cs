﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//Speed of player, this value may change as development continues
	private float speed = 15f;
	public float Speed {
		get{
			return speed;
		}set{
			speed = value;
		}
	}
	private float RAYCASTVIEW = 10;
	private Light myLight;
	private RaycastHit2D hit;
	private bool pause = false;
	private bool inCloset = false;

	//Audio
	private AudioSource[] source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;	
	private float audioDelay = 0.6f;
	private float audioTimer;
	public AudioClip walk;
	public AudioClip[] startSounds;


	// Use this for initialization
	void Start () {
        myLight = GameObject.Find("PlayerSpotlight").GetComponentInChildren<Light>();
		source = GetComponents<AudioSource> ();
		source[1].PlayOneShot (startSounds[Random.Range (0, 4)], 1f);
    }

	// Update is called once per frame
	void Update () {
		if (!pause) {
			//Get the coordinate of the mousepointer
			Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			//if the distance between the mouse and the player is greater than 10.1, don't know why that number     
			//the rotation based on the look rotation, it is then changed into a euler angle.
			if (Vector3.Distance (mouse, transform.position) > 10.1f) {
				transform.rotation = Quaternion.LookRotation (Vector3.forward, (mouse - transform.position).normalized);
			}

			//Movement of player
			//GetAxisRaw to get a value of -1, 0 or 1 so player snaps to full speed.
			transform.position += new Vector3 (0, Input.GetAxisRaw ("Vertical"), 0).normalized * speed * Time.deltaTime;
			transform.position += new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, 0).normalized * speed * Time.deltaTime;

			//Audio
			audioTimer += Time.deltaTime;
			WalkSound ();
			
			Flashlight ();
		}
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
		ToggleFlashlight ();
		if (myLight.enabled && !inCloset) {
            //all layers except the Player layer
            int mask = ~LayerMask.GetMask("Player");
			hit = Physics2D.Raycast(transform.position, raycastAngle(), RAYCASTVIEW, mask);
			if (hit.collider != null) {
				if (hit.collider.tag == "Wall" || hit.collider.tag == "Closet")  {
					return;
				}else if (hit.collider.tag == "Nurse") {
                    if (hit.collider.GetComponent<Nurse>().state == Nurse.states.PATROL)
                    {
                        hit.collider.GetComponent<Nurse>().state = Nurse.states.PLAYER;
                        hit.collider.GetComponent<Nurse>().Scream();
                    }
				}
			}
		}
	}

	void ToggleFlashlight(){
		if(Input.GetKeyDown(KeyCode.F)){
			myLight.enabled = !myLight.enabled;
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.collider.tag == "Pills") {
			Destroy (coll.gameObject);
			GetComponent<PlayerThrowing> ().pillBoxCount += 1;
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Closet") {
			inCloset = true;
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject.tag == "Closet") {
			inCloset = false;
		}
	}

	public bool getPlayerPause(){
		return pause;
	}

	public void setPlayerPause(bool pause){
		this.pause = pause;
	}

	Vector2 raycastAngle(){
		float radians = Mathf.Deg2Rad * (transform.eulerAngles.z + 90);
		return new Vector2 (Mathf.Cos (radians), Mathf.Sin (radians));
	}
}
