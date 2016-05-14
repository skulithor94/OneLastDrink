using UnityEngine;
using System.Collections;

public class SpeedPowerUp : MonoBehaviour {

	public AudioClip[] sounds;
	private AudioSource source;
	private Player player;
	private float duration = 3f;
	private float speedBoost = 10f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<Player> ();
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.collider.tag == "Player") {
			StartCoroutine (SpeedUp ());
		}
	}

	IEnumerator SpeedUp(){
		source.PlayOneShot (sounds[Random.Range (0, 1)], 1f);
		Destroy(gameObject.GetComponent<BoxCollider2D> ());
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		player.Speed += speedBoost;
		yield return new WaitForSeconds (duration);
		player.Speed -= speedBoost;
		Destroy (gameObject);
	}
}
