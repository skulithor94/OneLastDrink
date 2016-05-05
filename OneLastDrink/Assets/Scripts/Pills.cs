using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pills : MonoBehaviour {

	public Sprite[] pillSprites;
	public Image pillCountUI;
	private PlayerThrowing player;
	private float prevCount;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerThrowing>();
		prevCount = player.pillBoxCount;
	}
	
	// Update is called once per frame
	void Update () {
		if (prevCount != player.pillBoxCount) {
			pillCountUI.sprite = pillSprites [player.pillBoxCount];
			prevCount = player.pillBoxCount;
		}
	}
}
