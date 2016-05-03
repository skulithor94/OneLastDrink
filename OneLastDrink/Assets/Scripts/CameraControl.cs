using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Used to match the position of the camera to the position of the player.
		transform.position = new Vector3 (player.position.x, player.position.y, transform.position.z);
	}
}
