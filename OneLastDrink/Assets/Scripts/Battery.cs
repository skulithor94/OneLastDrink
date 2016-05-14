using UnityEngine;
using System.Collections;

public class Battery : MonoBehaviour {

	private Progress progress;

	public AudioClip[] sounds;
	private AudioSource source;
	private BoxCollider2D bc;
	private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		progress = GameObject.Find ("ProgressHandler").GetComponent<Progress> ();
		source = GetComponent<AudioSource> ();
		bc = GetComponent<BoxCollider2D> ();
		sr = GetComponent<SpriteRenderer> ();
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
			Debug.Log (coll.collider.tag);
			BatterySound ();
			bc.enabled = false;
			sr.enabled = false;
		}
	}

	void BatterySound(){
		source.PlayOneShot (sounds[Random.Range (0, 3)], 1f);
	}
}
