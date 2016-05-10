﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public void LoadLevel()
    {
        //Scene
        SceneManager.LoadScene("Level00");
    }
	public void LevelSelect()
	{
		//Scene
		SceneManager.LoadScene("LevelSelect");
	}
    public void TutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
