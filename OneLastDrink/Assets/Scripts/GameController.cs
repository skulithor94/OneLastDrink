using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Text;

public class GameController : MonoBehaviour {
 
    private float score;
	private GameObject[] nurses;
	private GameObject[] pills;
	private GameObject player;
	private GameObject canvasScore;
	private GameObject nextLevelButton;
    private ScoreManager scoreManager;
	private Animator anim;
	private string highscore;
	private string scoreString;

	public string scene;
	//public bool playerWin = false;

	// Use this for initialization
	void Start () { 
      
		player = GameObject.FindGameObjectWithTag ("Player");
		canvasScore = GameObject.Find ("Score");
		nextLevelButton = GameObject.Find ("NextLevelButton");
		anim = GameObject.Find("HUDCanvas").GetComponent<Animator> ();
		scoreManager = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
		nurses = GameObject.FindGameObjectsWithTag ("Nurse");

		canvasScore.SetActive (false);
		nextLevelButton.SetActive (false);

    }
	
	// Update is called once per frame
	void Update () {

	}

    //If the player wins the level a variable is set to true so the score can be computed
	//An animation is run and the score is displayed. Next the button which allows the player to
	//go to the next level is activated and the player is destoyed to turn of the lights.
    public void nextLevel()
    {
		pills = GameObject.FindGameObjectsWithTag("Pills");

		anim.SetTrigger ("NextLevel");
		canvasScore.SetActive (true);

		score = scoreManager.CalculateScore();

		displayScore ();

		nextLevelButton.SetActive (true);
        Destroy (player);
		foreach (GameObject nurse in nurses) {
			Destroy (nurse);
		}
		if(pills != null)
		{
			foreach(GameObject p in pills)
			{
				Destroy(p);
			}
		}
    }

	//Function returns the score of the player and the highscore of the current level.
	//It then converts the score into a character.
	string returnScore(){
		//float score = scoreManager.playerScore;
		highscore = PlayerPrefs.GetString(SceneManager.GetActiveScene().name);

		if ((score <= 500f && score >= 400f) || score > 500f) {
			return "A";
		} else if (score < 400f && score >= 300f) {
			return "B";
		} else if (score < 300f && score >= 200f) {
			return "C";
		} else if (score < 200f && score >= 100f) {
			return "D";
		} else if (score < 100f && score >= 50f) {
			return "E";
		}else{
			return "F";
		}
	}

	//Sets the highscore for the level if there is none. If the current score is higher than the 
	//current highscore then the highscore is updated.
	void displayScore(){
		scoreString = returnScore ();

		if (highscore == "" || (int)scoreString[0] < (int)highscore[0]) {
			PlayerPrefs.SetString (SceneManager.GetActiveScene().name, scoreString);
			highscore = PlayerPrefs.GetString(SceneManager.GetActiveScene().name);
		}

		canvasScore.GetComponent<Text> ().text = "Score: " + scoreString + " Highscore: " + highscore;
	}

	//Load the next scene which is declared in the object as a public variable.
	public void loadNextLevel(){
		//Load appropriate level
		SceneManager.LoadScene(scene);
	}
}
