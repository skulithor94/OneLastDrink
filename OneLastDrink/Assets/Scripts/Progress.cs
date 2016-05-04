using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class Progress : MonoBehaviour {

	//Gets the flashlight image and the speed at which the progress bar fills
	//could be changed to seconds later
	public Image flashlight;
	public float flashlightSpeed;
	public GameObject player;

	GameOverManager gameOverManager;

	// Use this for initialization
	void Start () {
		gameOverManager = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GameOverManager>();
	}
	
	// Update is called once per frame
	void Update () {
		//If the image's fill amount is 0 the game ends, if not the flashlight fill amount decreases.
		if (flashlight.fillAmount <= 0f) {
			//Destroy the current player so that the lights go out.
			Destroy (player);
			gameOverManager.gameOver ();
		}else{	
			flashlight.fillAmount -= flashlightSpeed * Time.deltaTime;
		}			
	}
		
}
