using UnityEngine;
using System.Collections;


public class PlayerThrowing : MonoBehaviour {

	public GameObject pillBoxPrefab;
	public float pillBoxCount = 1;
	public float fireDelay = 0.5f;
	float cooldownTimer = 0;
	
	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;
		if (Input.GetButton("Fire1") && cooldownTimer <= 0 && 0 < pillBoxCount ) {
			Debug.Log ("wow");
			cooldownTimer = fireDelay;
			Instantiate (pillBoxPrefab, transform.position, transform.rotation);
			pillBoxCount -= 1;
		}	
	}
}
