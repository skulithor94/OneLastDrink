using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//Speed of player, this value may change as development continues
	float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Get the coordinate of the mousepointer
		Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		//if the distance between the mouse and the player is greater than 10.1, don't know why that number
		//the rotation based on the look rotation, it is then changed into a euler angle.
		if (Vector3.Distance (mouse, transform.position) <= 10.1f) {
			transform.rotation = transform.rotation;
		} else {
			Quaternion rotChange = Quaternion.LookRotation (transform.position - mouse, Vector3.forward);
			transform.rotation = Quaternion.Euler (0, 0, rotChange.eulerAngles.z);
		}

		//The position of the player is recalculated based on the user's input and multiplied by the 
		//rotation to get controls to work as expected. 
		Vector3 posChange = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed * Time.deltaTime;
		transform.position += transform.rotation * posChange;
	}
}
