using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


    // Use this for initialization
    public void LoadLevel()
    {
        //Scene
        SceneManager.LoadScene("StoryScene");
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
    public void Highscore()
    {
        SceneManager.LoadScene("Highscore");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
