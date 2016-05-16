using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BeginScript : MonoBehaviour {

	public void LoadLevel()
	{
		//Scene
		SceneManager.LoadScene("Level00");
	}
}
