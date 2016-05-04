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

	// Use this for initialization
	void Start () {
		
        //Make sure we don't delete this after loading new scene
        DontDestroyOnLoad(gameObject);
		player = GameObject.FindGameObjectWithTag ("Player");
		canvasScore = GameObject.Find ("Score");
		nextLevelButton = GameObject.Find ("NextLevelButton");
		canvasScore.SetActive (false);
		nextLevelButton.SetActive (false);
		anim = GameObject.Find("HUDCanvas").GetComponent<Animator> ();

    }
	
	// Update is called once per frame
	void Update () {

	}
    
    public void nextLevel()
    {
		anim.SetTrigger ("NextLevel");
		canvasScore.SetActive (true);
		nextLevelButton.SetActive (true);
		Destroy (player);

        //SceneManager.LoadScene("HaukurTestScene");
        
    }
}
