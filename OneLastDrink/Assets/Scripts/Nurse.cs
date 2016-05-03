using UnityEngine;
using System.Collections;

public class Nurse : MonoBehaviour {

	public float speed;
	public Transform player, sightStart, sightEnd;
	public bool spotted = false;

	void Update(){
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.black);
		spotted = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
		if (spotted) {
			float z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
			transform.eulerAngles = new Vector3 (0, 0, z);
			GetComponent<Rigidbody2D>().AddForce (gameObject.transform.up * speed);
		}
	}

}
