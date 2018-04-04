using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dataController : MonoBehaviour {

	public static dataController DC;
	public bool twoPlayer;



	// Use this for initialization
	void Start () {

		DC = this;
		twoPlayer = false;
		DontDestroyOnLoad (gameObject);

		SceneManager.LoadScene (1);
		
	}




	public void switchPlayers(){

		twoPlayer = !twoPlayer;

	}

	

}
