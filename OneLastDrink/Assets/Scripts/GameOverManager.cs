 using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	//Two seconds given so the scene doesn't load immediately
	public float gameOverDelay = 3f;

	float gameOverTimer;
	Animator anim;
    public Image pillCountUI;
    public Button GORetryButton;
	public Button GOExitButton;
	public AudioClip[] sounds;

	private AudioSource source;
	private bool soundCheck = false;

	GameObject gameOverText;
	GameObject player;
    GameObject[] pills;
	GameObject[] nurses;


	// Use this for initialization
	void Start () {
		//Get the animator state machine that controls the game over animation
		anim = GameObject.Find("HUDCanvas").GetComponent<Animator> ();
		gameOverText = GameObject.Find ("GameOverText");
		gameOverText.SetActive (false);
		player = GameObject.FindGameObjectWithTag ("Player");
		nurses = GameObject.FindGameObjectsWithTag ("Nurse");
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame 
	void Update () {
    }

	public void gameOver(){
		if (!soundCheck) {
			source.PlayOneShot (sounds [Random.Range (0, 5)], 1f);
			soundCheck = true;
		}
		anim.SetTrigger ("GameOver");
		gameOverText.SetActive (true);
        pills = GameObject.FindGameObjectsWithTag("Pills");
        //Destroy the current player so that the lights go out.
        Destroy (player);
		foreach (GameObject nurse in nurses) {
			Destroy (nurse);
		}
        if(pills != null)
        {
            foreach(GameObject p in pills)
            {
                Destroy(p);
            }
        }
	}

	public void retry(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void exit(){
		SceneManager.LoadScene ("MainMenu");
	}
}
