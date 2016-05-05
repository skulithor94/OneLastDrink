using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public void LoadLevel()
    {
        //Scene
        SceneManager.LoadScene("Level00");
    }
}
