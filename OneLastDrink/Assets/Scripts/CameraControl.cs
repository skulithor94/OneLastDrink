using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public Transform player;
	public float smooting = 5f;

	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.position;
		transform.position = player.position;
	}
	
	// Update is called once per frame
	void Update () {

		//Used to match the position of the camera to the position of the player.
		if (player != null) {
			Vector3 targetCamPos = player.position + offset;
			transform.position = Vector3.Lerp (transform.position, targetCamPos, smooting * Time.deltaTime);
		//	transform.position = new Vector3 (player.position.x, player.position.y, transform.position.z);
		}
	}
}
