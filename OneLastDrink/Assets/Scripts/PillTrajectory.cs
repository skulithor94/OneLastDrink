using UnityEngine;
using System.Collections;

public class PillTrajectory : MonoBehaviour {

	float maxSpeed = 25;
	float deceleration = 0.98f;


	void Start(){
		/*Vector2 forward = new Vector2 (gameObject.transform.localScale.x, gameObject.transform.localScale.y);
		gameObject.GetComponent<Rigidbody2D> ().AddForce (forward*10);*/
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (5 < maxSpeed) {
			Vector3 pos = transform.position;

			Vector3 velocity = new Vector3 (0, maxSpeed * Time.deltaTime, 0);
			pos += transform.rotation * velocity;
			transform.position = pos;
			maxSpeed *= deceleration;
		}

	}
}
