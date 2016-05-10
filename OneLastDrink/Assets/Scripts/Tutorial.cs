using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {
    public GameObject startMessage;
    public GameObject throwPills;
    public GameObject pillThrown;
    public GameObject nurseAttack;
    public GameObject playerCaught;
    public GameObject closet;
    public GameObject inCloset;
    public GameObject gameOverText;
    GameObject player;
    GameObject[] pills;
    Animator anim;
    //Make Array of text objects
    // Use this for initialization
    void Start () {
        anim = GameObject.Find("TutorialCanvas").GetComponent<Animator>();
        gameOverText.SetActive(false);
        throwPills.SetActive(false);
        pillThrown.SetActive(false);
        nurseAttack.SetActive(false);
        playerCaught.SetActive(false);
        closet.SetActive(false);
        inCloset.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Need this on player
        if (coll.gameObject.tag == "ObjectiveBox")
        {
            //Making sure that only one text at a time is displayed
            //Need to find a better way
            startMessage.SetActive(false);
            throwPills.SetActive(true);
            pillThrown.SetActive(false);
            nurseAttack.SetActive(false);
            playerCaught.SetActive(false);
            closet.SetActive(false);
            inCloset.SetActive(false);
        }
        //Need this on player
        if (coll.gameObject.tag == "Closet")
        {
           // Debug.Log("Spuderman");
            startMessage.SetActive(false);
            throwPills.SetActive(false);
            pillThrown.SetActive(false);
            nurseAttack.SetActive(false);
            playerCaught.SetActive(false);
            closet.SetActive(false);
            inCloset.SetActive(true);
        }
        //Need this on player
        if (coll.gameObject.tag == "Pills")
        {
            Destroy(coll.gameObject);
            //Making sure that only one text at a time is displayed
            //Need to find a better way
            startMessage.SetActive(false);
            throwPills.SetActive(false);
            pillThrown.SetActive(true);
            nurseAttack.SetActive(false);
            playerCaught.SetActive(false);
            closet.SetActive(false);
            inCloset.SetActive(false);
        }
        if (coll.gameObject.tag == "LiveNurse")
        {
            startMessage.SetActive(false);
            throwPills.SetActive(false);
            pillThrown.SetActive(false);
            nurseAttack.SetActive(true);
            playerCaught.SetActive(false);
            closet.SetActive(false);
            inCloset.SetActive(false);

        }
        if (coll.gameObject.tag == "ClosetImage")
        {
            startMessage.SetActive(false);
            throwPills.SetActive(false);
            pillThrown.SetActive(false);
            nurseAttack.SetActive(false);
            playerCaught.SetActive(false);
            closet.SetActive(true);
            inCloset.SetActive(false);

        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //When pills collide with nurses
        //Need this on NurseImage nothing more
        if (col.collider.tag == "Nurse")
        {
            player = GameObject.Find("Player");
            startMessage.SetActive(false);
            throwPills.SetActive(false);
            pillThrown.SetActive(false);
            nurseAttack.SetActive(false);
            playerCaught.SetActive(true);
            closet.SetActive(false);
            inCloset.SetActive(false);
            Destroy(col.gameObject);
            //Destroy the current player so that the lights go out.
            Destroy(player);
            gameOver();
        }
    }
    public void gameOver()
    {
        anim.SetTrigger("GameOver");
        gameOverText.SetActive(true);
        startMessage.SetActive(false);
        throwPills.SetActive(false);
        pillThrown.SetActive(false);
        nurseAttack.SetActive(false);
        playerCaught.SetActive(false);
        closet.SetActive(false);
        inCloset.SetActive(false);
        pills = GameObject.FindGameObjectsWithTag("Pills");
        if (pills != null)
        {
            foreach (GameObject p in pills)
            {
                Destroy(p);
            }
        }
    }

    public void retry()
    {
        Debug.Log("DO we go here");
        SceneManager.LoadScene("Tutorial");
    }

    public void exit()
    {
        Debug.Log("Do we go here");
        SceneManager.LoadScene("MainMenu");
    }
}
