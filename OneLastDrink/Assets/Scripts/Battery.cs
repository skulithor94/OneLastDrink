using UnityEngine;
using System.Collections;

public class Battery : MonoBehaviour {

	private Progress progress;

	// Use this for initialization
	void Start () {
		progress = GameObject.Find ("ProgressHandler").GetComponent<Progress> ();
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.collider.tag == "Player") {
			if (progress.flashlight.fillAmount <= 0.9f) {
				progress.flashlight.fillAmount += 0.1f;
			} else {
				progress.flashlight.fillAmount = 1f;
			}
		}
		Destroy (gameObject);
	}
}
