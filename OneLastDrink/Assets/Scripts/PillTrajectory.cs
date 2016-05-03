using UnityEngine;
using System.Collections;

public class PillTrajectory : MonoBehaviour {

	float maxSpeed = 25;
	float deceleration = 0.98f;

	void Start(){
	}

	// Update is called once per frame
	void Update () {
		if (5 < maxSpeed) {
			Vector3 pos = transform.position;

			Vector3 velocity = new Vector3 (0, maxSpeed * Time.deltaTime, 0);
			pos += transform.rotation * velocity;
			transform.position = pos;
			maxSpeed *= deceleration;
		}


	}
}
