using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

	private Player player;
	private PlayerThrowing playerThrow;
	public GameObject panel;
	public AudioMixer masterMixer;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		playerThrow = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerThrowing> ();
		panel.SetActive (false);
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
}
