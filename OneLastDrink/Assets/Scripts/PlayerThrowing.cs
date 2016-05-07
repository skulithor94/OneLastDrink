using UnityEngine;
using System.Collections;


public class PlayerThrowing : MonoBehaviour {

	public GameObject pillBoxPrefab;
	public int pillBoxCount = 3;
	public float fireDelay = 0.5f;
	float cooldownTimer = 0;

	public AudioClip throwPill;
	private AudioSource[] source;

	void Start(){
		source = GetComponents<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;
		if (Input.GetButton("Fire1") && cooldownTimer <= 0 && 0 < pillBoxCount ) {
			//Debug.Log ("wow");
			cooldownTimer = fireDelay;
			Vector3 offset = transform.rotation * new Vector3 (0, 2.6f, 0);
			Instantiate (pillBoxPrefab, transform.position + offset, transform.rotation);
			pillBoxCount -= 1;

			source [1].PlayOneShot (throwPill, 1f);
		}	
	}
}
