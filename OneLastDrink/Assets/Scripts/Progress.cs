using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class Progress : MonoBehaviour {

	//Gets the flashlight image and the speed at which the progress bar fills
	//could be changed to seconds later
	public Image flashlight;
	public float flashlightSpeed;
    private bool hasColorChanged;
    public Image foregroundColor;

    GameOverManager gameOverManager;

	// Use this for initialization
	void Start () {
		//Allows for interaction with gameOverManager functions
		gameOverManager = GameObject.FindGameObjectWithTag("GameOverManager").GetComponent<GameOverManager>();
        hasColorChanged = false;
    }
	
	// Update is called once per frame
	void Update () {
        /*if (flashlight.fillAmount < 0.4f & flashlight.fillAmount > 0f)
        {
            if (hasColorChanged == false)
            {
                Debug.Log("Time is running out");
                foregroundColor = GameObject.Find("Foreground").GetComponent<Image>();

                // Color red = new Color(255, 9, 0, 1);
                //foregroundColor.material.color = Color.red;

                Debug.Log(flashlight);
                hasColorChanged = true;
            }
        }*/
        //If the image's fill amount is 0 the game ends, if not the flashlight fill amount decreases.
        if (flashlight.fillAmount <= 0f) {
			gameOverManager.gameOver ();
		}else{	
			flashlight.fillAmount -= flashlightSpeed * Time.deltaTime;
		}			
	}
		
}
