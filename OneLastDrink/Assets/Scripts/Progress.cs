﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class Progress : MonoBehaviour {

	//Gets the flashlight image and the speed at which the progress bar fills
	//could be changed to seconds later
	public Image flashlight;
	public float flashlightSpeed;
    public Image warning;
   // public Image foregroundColor;

    GameOverManager gameOverManager;
    Tutorial tutorial;

    // Use this for initialization
    void Start () {
		//Allows for interaction with gameOverManager functions
		gameOverManager = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GameOverManager>();
        if (GameObject.Find("HUDCanvas") == null)
        {
            tutorial = GameObject.FindGameObjectWithTag("Tutorial").GetComponent<Tutorial>();
        }
        warning.enabled = false;
    } 
	
	// Update is called once per frame
	void Update () {
		if (flashlight.fillAmount >= 0.4f) {
			flashlight.enabled = true;
		}else if (flashlight.fillAmount > 0f && flashlight.fillAmount < 0.4){
            //Disable the green flashlight
            flashlight.enabled = false;
            //Enable the warning flashlight
            warning.enabled = true;
        }
        //If the image's fill amount is 0 the game ends, if not the flashlight fill amount decreases.
        if (flashlight.fillAmount <= 0f) {
            if (GameObject.Find("HUDCanvas") == null)
            {
                tutorial.gameOver();
            }
            else
            {
                gameOverManager.gameOver();
            }
		}else{	
			flashlight.fillAmount -= flashlightSpeed * Time.deltaTime;
            warning.fillAmount -= flashlightSpeed * Time.deltaTime;
		}			
	}
		
}
