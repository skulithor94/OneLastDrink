﻿using UnityEngine;
using System.Collections;

public class Nurse : MonoBehaviour {

	public float speed;
	public Transform player, following;
	public RaycastHit2D hit;
	public enum states {PATROL, PILLS, PLAYER, DRUGGED};
	public states state;
	public float onDrugs, drugPhase = 3f;

	void Start(){
		state = states.PATROL;
	}


	void FixedUpdate(){
		hit = Physics2D.Raycast (transform.position, -Vector2.up, 30, LayerMask.GetMask("Player"));

		switch (state) {
		case states.PATROL:
			patrol ();
			break;
		case states.PILLS:
			followPills ();
			break;
		case states.PLAYER:
			followPlayer ();
			break;
		case states.DRUGGED:
			highAsAKite ();
			break;
		}

		/*if (spotted) {
			float z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
			transform.eulerAngles = new Vector3 (0, 0, z);
			GetComponent<Rigidbody2D>().AddForce (gameObject.transform.up * speed);
		}*/
	}

	void patrol() {
		if (hit.collider != null) {
			following = hit.transform.gameObject.transform;
			if (hit.collider.tag == "Pills") {
				state = states.PILLS;
				GetComponent<Rigidbody2D> ().AddForce (gameObject.transform.up * speed);
			} else if (hit.collider.tag == "Player") {
				state = states.PLAYER;
			}
		}
	}

	void followPills(){
		float z = Mathf.Atan2 ((following.position.y - transform.position.y), (following.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3 (0, 0, z);
		GetComponent<Rigidbody2D>().AddForce (gameObject.transform.up * speed);
	}

	void followPlayer(){
		float z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3 (0, 0, z);
		GetComponent<Rigidbody2D>().AddForce (gameObject.transform.up * speed);
	}

	void highAsAKite(){
		if (onDrugs >= drugPhase) {
			onDrugs = 0f;
			state = states.PATROL;
			GetComponent<Rigidbody2D> ().rotation = 180;
		}
		else if(onDrugs < drugPhase){
			onDrugs += Time.deltaTime;
			GetComponent<Rigidbody2D> ().rotation += 5;
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.collider.tag == "Pills") {
			Destroy (GameObject.FindWithTag("Pills"));
			state = states.DRUGGED;
		}
	}

}
