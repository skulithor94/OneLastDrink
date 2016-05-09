using UnityEngine;
using System.Collections;

public class Nurse : MonoBehaviour {

	public float speed;
	public Transform player, following;
	public RaycastHit2D hit;
	public enum states {PATROL, PILLS, PLAYER, DRUGGED};
	public states state;
	public float onDrugs, drugPhase = 3f;
	public AudioClip scream;
	public AudioClip walk;
	float RAYCASTVIEW = 15;
	GameOverManager gameOverManager;
    private Collider2D[] colliders;

	//Audio
	private AudioSource[] sources;
	private float audioDelay = 0.4f; //This number might need to be tweaked. 
	private float audioTimer;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;


	void Start(){
		state = states.PATROL;
		gameOverManager = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GameOverManager>();
        colliders = gameObject.GetComponents<Collider2D>();
		sources = GetComponents<AudioSource> ();
	}

	void FixedUpdate(){
		switch (state) {
		case states.PATROL:
            patrol();
			break;
		case states.PILLS:
			followPills ();
			break;
		case states.PLAYER:
			followPlayer ();
			break;
		case states.DRUGGED:
			highAsAKite ();
			break;
		}		
	}
   
	void patrol() {
            hit = Physics2D.Raycast(transform.position, raycastAngle(), RAYCASTVIEW, LayerMask.GetMask("Player"));
            if (hit.collider != null)
            {
                following = hit.transform.gameObject.transform;
                if (hit.collider.tag == "Pills")
                {
                    state = states.PILLS;
                }
                else if (hit.collider.tag == "Player")
                {
                    state = states.PLAYER;
					Scream ();
                }
            }
        
	}

    void followPills()
    {
        //colliders[0].isTrigger = false;
        //Doesn't follow the pill but returns to patrol state and sees nothing..
        float z = Mathf.Atan2((following.position.y - transform.position.y), (following.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, z);
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed);
		WalkSound ();
	}

    void followPlayer(){
		float z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3 (0, 0, z);
		GetComponent<Rigidbody2D>().AddForce (gameObject.transform.up * speed);
		WalkSound ();
	}

	void highAsAKite(){
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		if (onDrugs >= drugPhase) {
			onDrugs = 0f;
			following = null;
			GetComponent<Rigidbody2D> ().angularVelocity = 0f;
            confNurseColliders(true);
            state = states.PATROL;
		}
		else if(onDrugs < drugPhase){
            confNurseColliders(false);
            onDrugs += Time.deltaTime;
			GetComponent<Rigidbody2D> ().transform.Rotate(new Vector3(0,0,5));
        }
	}

    void confNurseColliders(bool enabled)
    {
        foreach(Collider2D c in colliders)
        {
            c.enabled = enabled;
        }
    }

	Vector2 raycastAngle(){
		float radians = Mathf.Deg2Rad * (transform.eulerAngles.z + 90);
		return new Vector2 (Mathf.Cos (radians), Mathf.Sin (radians));
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.collider.tag == "Pills") {
			Destroy (coll.gameObject);
            state = states.DRUGGED;
		}
		if (coll.collider.tag == "Player") {
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			gameOverManager.gameOver ();
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Pills") {
			following = coll.gameObject.transform;
			state = states.PILLS;
		}
	}

	//Plays the scream audio clip, which is in the second audio source
	//at max volume.
	void Scream(){
		sources [1].PlayOneShot (scream, 1f);
	}

	//Play walking sound if the delay has passed. 
	//There is a fluctuation in volume so that the sound doesn't become to bland.
	void WalkSound(){
		if(audioTimer >= audioDelay){
			float vol = Random.Range (volLowRange, volHighRange);
			audioTimer = 0f;
			sources[0].PlayOneShot (walk, vol);
		}
	}

	//Only used for audio. Might work in fixed update but because
	//it's not physics I don't know.
	void Update(){
		audioTimer += Time.deltaTime;
	}
}
