using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour {
    // Use this for initialization
    public GameController gameController;
    public GameObject player;
    // Use this for initialization
    void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Start()
    {
		
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            gameController.nextLevel();
        } 

    }

}
