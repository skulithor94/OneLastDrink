using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

	public void LoadLevel00()
	{
		//Scene
		SceneManager.LoadScene("Level00");
	}
	public void LoadLevel01()
	{
		//Scene
		SceneManager.LoadScene("Level01");
	}
	public void Back()
	{
		//Scene
		SceneManager.LoadScene("MainMenu");
	}

}
