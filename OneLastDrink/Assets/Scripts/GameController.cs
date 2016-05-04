using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
   // public GUIText gameOverT;


    //public GUIText scoreText;
   // private bool WinLevel;
    private bool nextLevel;
    private int score;

   // private bool gameOverb = false;
	// Use this for initialization
	void Start () {
       // WinLevel = false;
        nextLevel = false;
        //scoreText.text = "";
        //Make sure we don't delete this after loading new scene
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
        if(nextLevel)
        {
            if(Input.GetKeyDown(KeyCode.Y))
            {
                SceneManager.LoadScene("HaukurTestScene");
            }
        }
	}
    
    public void GameOver()
    {
     //   gameOverT.text = "Game Over!";
        //gameOverb = true;
    }
    public void GameWin()
    {
        Time.timeScale = 0.5f;
       // scoreText.text = "You have won!";
       // WinLevel = true;
        nextLevel = true;
        //Print out score
        //Print out level nr and write completed
        //Go to next level
        //Time.timeScale = 1000f;
        //Set the game to pause until next level
        //For pause
        // Time.timeScale = 0;
        //If button pushed to go to next level 

        //SceneManager.LoadScene("HaukurTestScene");
        //CODE
        Debug.Log("Entering GameController");
    }
}
