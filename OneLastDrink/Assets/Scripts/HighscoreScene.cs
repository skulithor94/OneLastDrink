using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoreScene : MonoBehaviour {
    //Text objects
    public Text Level00;
    public Text Level01;
    public Text Level02;
    public Text Level03;
    public Text Level04;
    public Text Level05;

    private string highscoreLevel00;
    private string highscoreLevel01;
    private string highscoreLevel02;
    private string highscoreLevel03;
    private string highscoreLevel04;
    private string highscoreLevel05;

    // Use this for initialization
    void Start () {

        //Get the highscore for each level, hardcoded
        highscoreLevel00 = PlayerPrefs.GetString("Level00");
        highscoreLevel01 = PlayerPrefs.GetString("Level01");
        highscoreLevel02 = PlayerPrefs.GetString("Level02");
        highscoreLevel03 = PlayerPrefs.GetString("Level03");
        highscoreLevel04 = PlayerPrefs.GetString("Level04");
        highscoreLevel05 = PlayerPrefs.GetString("Level05");

        //Set the text with the highscore
        Level00.text = highscoreLevel00;
        Level01.text = highscoreLevel01;
        Level02.text = highscoreLevel02;
        Level03.text = highscoreLevel03;
        Level04.text = highscoreLevel04;
        Level05.text = highscoreLevel05;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Back()
    {
        //Scene
        SceneManager.LoadScene("MainMenu");
    }
}
