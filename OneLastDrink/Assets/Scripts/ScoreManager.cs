using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class ScoreManager : MonoBehaviour {

	float score = 500f;
	public float playerScore;
	public string highscore;

	private PlayerThrowing playerThrow;
	private Progress progressHandler;

	// Use this for initialization
	void Start () {
		progressHandler = GameObject.Find ("ProgressHandler").GetComponent<Progress>();
		playerThrow = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerThrowing> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public float CalculateScore(){
		playerScore = score * progressHandler.flashlight.fillAmount;
		playerScore = (float)Math.Floor (playerScore);
		playerScore += playerThrow.pillBoxCount * 10;
		return playerScore;
	}
}
