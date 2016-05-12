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
    public void LoadLevel02()
    {
        //Scene
        SceneManager.LoadScene("Level02");
    }
    public void LoadLevel03()
    {
        //Scene
        SceneManager.LoadScene("Level03");
    }
    public void LoadLevel04()
    {
        //Scene
        SceneManager.LoadScene("Level04");
    }
    public void Back()
	{
		//Scene
		SceneManager.LoadScene("MainMenu");
	}

}
