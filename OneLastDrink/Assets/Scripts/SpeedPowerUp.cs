using UnityEngine;
using System.Collections;

public class SpeedPowerUp : MonoBehaviour {

	private Player player;
	private float duration = 3f;
	private float speedBoost = 20f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<Player> ();
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
		Destroy(gameObject.GetComponent<BoxCollider2D> ());
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		player.Speed += speedBoost;
		yield return new WaitForSeconds (duration);
		player.Speed -= speedBoost;
		Destroy (gameObject);
	}
}
