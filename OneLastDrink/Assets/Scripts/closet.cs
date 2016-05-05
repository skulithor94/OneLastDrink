using UnityEngine;
using System.Collections;

public class closet : MonoBehaviour {

	Nurse[] nurses;


	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			nurses = GameObject.FindObjectsOfType<Nurse> ();
			foreach (Nurse nurse in nurses) {
				nurse.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
				if (nurse.state != Nurse.states.PATROL) {
					nurse.state = Nurse.states.DRUGGED;
				}
			}
		}
	}
}
