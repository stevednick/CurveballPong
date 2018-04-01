using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class control : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Horizontal")){
			player.GetComponent<playerScript> ().leftPressed = true;
		}
		if (Input.GetButtonUp ("Horizontal")) {
			player.GetComponent<playerScript> ().leftPressed = false;
		}
		if(Input.GetButtonDown("Vertical")){
			player.GetComponent<playerScript> ().rightPressed = true;
		}
		if (Input.GetButtonUp ("Vertical")) {
			player.GetComponent<playerScript> ().rightPressed = false;
		}
		
	}

	public void changeScene(int s){
		SceneManager.LoadScene (s);
	}
}
