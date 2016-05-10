using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

	private Player player;
	private PlayerThrowing playerThrow;
	private Slider[] sliders;
	public GameObject panel;
	public AudioMixer masterMixer;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		playerThrow = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerThrowing> ();
		panel.SetActive (false);

		sliders = panel.GetComponentsInChildren<Slider> ();
		InitializeVolume ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Time.timeScale == 1) {
				Pause ();
			} else {
				Unpause ();
			}
		}
	}

	//Pause the game, need to pause the player so what lookrotation doesn't change.
	//The playerThrow needs to be paused so that the player can't throw pills while the game is paused.
	public void Pause(){
		Time.timeScale = 0;
		player.setPlayerPause (true);
		playerThrow.setPlayerPause (true);
		panel.SetActive (true);
	}
		
	public void Unpause(){
		Time.timeScale = 1;
		player.setPlayerPause (false);	
		playerThrow.setPlayerPause (false);
		panel.SetActive (false);
	}

	public void Exit(){
		Unpause ();
		SceneManager.LoadScene("MainMenu");
	}
		
	public void SetSfxVol(float sfxLvl){
		masterMixer.SetFloat ("effectsVol", sfxLvl);
	}

	public void SetMusicVol(float musicLvl){
		masterMixer.SetFloat ("musicVol", musicLvl);
	}

	public void SetMasterVol(float masterLvl){
		masterMixer.SetFloat ("masterVol", masterLvl);
	}

	//Initialize the sliders in the pause menu based on the values of the mixer.
	private void InitializeVolume(){
		float vol;

		masterMixer.GetFloat ("effectsVol", out vol);
		sliders [0].value = vol;

		masterMixer.GetFloat ("masterVol", out vol);
		sliders [1].value = vol;

		masterMixer.GetFloat ("musicVol", out vol);
		sliders [2].value = vol;	
	}
}
