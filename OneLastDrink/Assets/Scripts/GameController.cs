using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
 
    private int score;
	GameObject player;
	GameObject canvasScore;
	GameObject nextLevelButton;
	Animator anim;

	public string scene;
	public bool playerWin = false;

	// Use this for initialization
	void Start () { 
      
		player = GameObject.FindGameObjectWithTag ("Player");
		canvasScore = GameObject.Find ("Score");
		nextLevelButton = GameObject.Find ("NextLevelButton");
		anim = GameObject.Find("HUDCanvas").GetComponent<Animator> ();

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
		playerWin = true;
		anim.SetTrigger ("NextLevel");
		canvasScore.SetActive (true);
		canvasScore.GetComponent<Text> ().text = "Score:" + returnScore ();
		nextLevelButton.SetActive (true);
		Destroy (player);
    }

	string returnScore(){
		float score = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ().playerScore;

		if (score <= 500f && score >= 450f) {
			return "A";
		} else if (score < 450f && score >= 400f) {
			return "B";
		} else if (score < 400f && score >= 300f) {
			return "C";
		} else if (score < 300f && score >= 200f) {
			return "D";
		} else if (score < 200f && score >= 100f) {
			return "E";
		}else{
			return "F";
		}
	}

	//Load the next scene which is declared in the object as a public variable.
	public void loadNextLevel(){
		//Load appropriate level
		SceneManager.LoadScene(scene);
	}
}
