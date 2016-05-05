using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//Speed of player, this value may change as development continues
	float speed = 10f;
    private Light myLight;

	// Use this for initialization
	void Start () {
        //Find the flashlight
        myLight = GameObject.Find("PlayerSpotlight").GetComponentInChildren<Light>();
    }
	
	// Update is called once per frame
	void Update () {

		//Get the coordinate of the mousepointer
		Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//if the distance between the mouse and the player is greater than 10.1, don't know why that number     
		//the rotation based on the look rotation, it is then changed into a euler angle.
		if (Vector3.Distance (mouse, transform.position) <= 10.1f) {
			transform.rotation = transform.rotation; //THIS IS POINTLESS!
		} else {
			transform.rotation = Quaternion.LookRotation (Vector3.forward, (mouse - transform.position).normalized);
		}

		//The position of the player is recalculated based on the user's input and multiplied by the 
		//rotation to get controls to work as expected. 
		Vector3 posChange = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed * Time.deltaTime;
		transform.position += transform.rotation * posChange;

        if(Input.GetKeyDown(KeyCode.F))
        {
            //Enable the flashlight//Or disable
            myLight.enabled = !myLight.enabled;
        }
	}
}
