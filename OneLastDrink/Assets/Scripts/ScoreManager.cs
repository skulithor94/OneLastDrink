using UnityEngine;
using System.Collections;
using System;

public class ScoreManager : MonoBehaviour {

	float score = 500f;
	public float playerScore;
	Progress progressHandler;
	GameController gameController;

	// Use this for initialization
	void Start () {
		progressHandler = GameObject.Find ("ProgressHandler").GetComponent<Progress>();
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}

	// Update is called once per frame
	void Update () {
		//Calculate player score based on the amount of time left on the level.
		if (!gameController.playerWin) {
			playerScore = score * progressHandler.flashlight.fillAmount;
			playerScore = (float)Math.Floor (playerScore);
		}
	}
}
