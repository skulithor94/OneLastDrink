using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
    public GameObject startMessage;
    public GameObject throwPills;
    public GameObject pillThrown;
    public GameObject nurseAttack;
    public GameObject playerCaught;
    public GameObject closet;
    public Nurse nurse;
    //Make Array of text objects
    // Use this for initialization
    void Start () {
        throwPills.SetActive(false);
        pillThrown.SetActive(false);
        nurseAttack.SetActive(false);
        playerCaught.SetActive(false);
        closet.SetActive(false);
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
        }
        //Need this on player
        if (coll.gameObject.tag == "Closet")
        {
            Debug.Log("Spuderman");
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
        }
        if (coll.gameObject.tag == "LiveNurse")
        {
            startMessage.SetActive(false);
            throwPills.SetActive(false);
            pillThrown.SetActive(false);
            nurseAttack.SetActive(true);
            playerCaught.SetActive(false);
            closet.SetActive(false);

        }
        if (coll.gameObject.tag == "ClosetImage")
        {
            startMessage.SetActive(false);
            throwPills.SetActive(false);
            pillThrown.SetActive(false);
            nurseAttack.SetActive(false);
            playerCaught.SetActive(false);
            closet.SetActive(true);

        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //When pills collide with nurses
        //Need this on NurseImage nothing more
        if (col.collider.tag == "Nurse")
        {
            startMessage.SetActive(false);
            throwPills.SetActive(false);
            pillThrown.SetActive(false);
            nurseAttack.SetActive(false);
            playerCaught.SetActive(true);
            closet.SetActive(false);
            //She stops moving after she catches you
            nurse.speed = 0;
        }
    }
}
