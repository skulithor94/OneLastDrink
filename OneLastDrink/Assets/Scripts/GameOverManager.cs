using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	//Two seconds given so the scene doesn't load immediately
	public float gameOverDelay = 2f;

	bool gameOverCheck = false;
	float gameOverTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOverCheck) {

			gameOverTimer += Time.deltaTime;

			if (gameOverTimer >= gameOverDelay) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			}
		}
	}   

	public void gameOver(){
		gameOverCheck = true;
	}
}
