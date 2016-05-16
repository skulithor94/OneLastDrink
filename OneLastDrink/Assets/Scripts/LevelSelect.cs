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

    public void LoadLevel05()
    {
        //Scene
        SceneManager.LoadScene("Level05");
    }
    public void LoadLevel06()
    {
        //Scene
        SceneManager.LoadScene("Level06");
    }
    public void LoadLevel07()
    {
        //Scene
        SceneManager.LoadScene("Level07");
    }
    public void Back()
	{
		//Scene
		SceneManager.LoadScene("MainMenu");
	}

}
