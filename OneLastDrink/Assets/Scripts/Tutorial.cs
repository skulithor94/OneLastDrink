using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {
    public GameObject startMessage;
    public GameObject throwPills;
    public GameObject pillThrown;
    public GameObject nurseAttack;
    public GameObject closet;
    public GameObject inCloset;
    public GameObject gameOverText;
    private float duration = 3f;
    GameObject player;
    GameObject[] pills;
    Animator anim;
    //Make Array of text objects
    // Use this for initialization
    void Start () {
        anim = GameObject.Find("TutorialCanvas").GetComponent<Animator>();
        SetMessageToFalse();
        //startMessage.SetActive(true);
    }
    void SetMessageToFalse()
    {
        startMessage.SetActive(false);
        gameOverText.SetActive(false);
        throwPills.SetActive(false);
        pillThrown.SetActive(false);
        nurseAttack.SetActive(false);
        closet.SetActive(false);
        inCloset.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "StartingPoint")
        {
            startMessage.SetActive(false);
        }
        if (coll.gameObject.tag == "ObjectiveBox")
        {
            throwPills.SetActive(false);
        }
        if (coll.gameObject.tag == "Closet")
        {
            inCloset.SetActive(false);
        }
        if (coll.gameObject.tag == "Step3Tutorial")
        {
            nurseAttack.SetActive(false);
        }
        if (coll.gameObject.tag == "ClosetImage")
        {
            // SetMessageToFalse();
            closet.SetActive(false);

        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "StartingPoint")
        {
            startMessage.SetActive(true);
        }

        if (coll.gameObject.tag == "ObjectiveBox")
        {
            // SetMessageToFalse();
          //  startMessage.SetActive(false);
            throwPills.SetActive(true);
        }
        if (coll.gameObject.tag == "Closet")
        {
            //SetMessageToFalse();
            inCloset.SetActive(true);
        }
        if (coll.gameObject.tag == "Pills")
        {
            Destroy(coll.gameObject);
            //SetMessageToFalse();
            pillThrown.SetActive(true);
            StartCoroutine(wait3Seconds());

        }
        if (coll.gameObject.tag == "Step3Tutorial")
        {
            //SetMessageToFalse();
            nurseAttack.SetActive(true);

        }
        if (coll.gameObject.tag == "ClosetImage")
        {
           // SetMessageToFalse();
            closet.SetActive(true);

        }
        if(coll.gameObject.tag == "Exit")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Nurse")
        {
            player = GameObject.Find("Player");
            //SetMessageToFalse();
            Destroy(col.gameObject);
            
            gameOver();
        }
    }
    public void gameOver()
    {
        anim.SetTrigger("GameOver");
       // SetMessageToFalse();
        gameOverText.SetActive(true);
        Destroy(player);
        pills = GameObject.FindGameObjectsWithTag("Pills");
        if (pills != null)
        {
            foreach (GameObject p in pills)
            {
                Destroy(p);
            }
        }
    }

    public void retryTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void exitMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    IEnumerator wait3Seconds()
    {
        yield return new WaitForSeconds(duration);
        pillThrown.SetActive(false);

    }

}
