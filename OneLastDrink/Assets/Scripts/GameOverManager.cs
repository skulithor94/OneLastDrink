using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	//Two seconds given so the scene doesn't load immediately
	public float gameOverDelay = 3f;

	float gameOverTimer;
	Animator anim;
	public Button GORetryButton;
	public Button GOExitButton;
	GameObject gameOverText;
	GameObject player;
	Nurse[] nurses;

	// Use this for initialization
	void Start () {
		//Get the animator state machine that controls the game over animation
		anim = GameObject.Find("HUDCanvas").GetComponent<Animator> ();
		gameOverText = GameObject.Find ("GameOverText");
		gameOverText.SetActive (false);
		player = GameObject.FindGameObjectWithTag ("Player");
		nurses = GameObject.FindObjectsOfType<Nurse> ();
		Debug.Log (nurses);
	}
	
	// Update is called once per frame 
	void Update () {

	}

	public void gameOver(){
		anim.SetTrigger ("GameOver");
		gameOverText.SetActive (true);

		//Destroy the current player so that the lights go out.
		Destroy (player);
		foreach (Nurse nurse in nurses) {
			Destroy (nurse);
		}
	}

	public void retry(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void exit(){
		SceneManager.LoadScene ("MainMenu");
	}
}
