using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		Quaternion rot = transform.rotation;

		Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		if (Vector3.Distance (mouse, transform.position) <= 10.1f) {
			transform.rotation = transform.rotation;
		} else {
			Quaternion rotChange = Quaternion.LookRotation (transform.position - mouse, Vector3.forward);
			transform.rotation = Quaternion.Euler (0, 0, rotChange.eulerAngles.z);
		}

		Vector3 posChange = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed * Time.deltaTime;
		//pos += transform.rotation * posChange;
		transform.position += transform.rotation * posChange;
	}
}
