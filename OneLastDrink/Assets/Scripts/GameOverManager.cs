using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	//Two seconds given so the scene doesn't load immediately
	public float gameOverDelay = 3f;

	//Scripts that cause death cause this variable to turn true when gameOver is called
	bool gameOverCheck = false;
	float gameOverTimer;
	Animator anim;

	// Use this for initialization
	void Start () {
		//Get the animator state machine that controls the game over animation
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOverCheck) {

			//Trigger the animation to start and start the delay so the level doesn't load immediately
			anim.SetTrigger ("GameOver");
			gameOverTimer += Time.deltaTime;

			if (gameOverTimer >= gameOverDelay) {
				//Loads the current level, might recondsider loading the main menu
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			}
		}
	}

	public void gameOver(){
		gameOverCheck = true;
	}
}
