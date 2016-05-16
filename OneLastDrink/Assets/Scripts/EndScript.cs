using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour {

	public void LoadLevel()
	{
		//Scene
		SceneManager.LoadScene("MainMenu");
	}
}
