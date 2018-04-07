using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dataController : MonoBehaviour {

	public static dataController DC;
	public bool twoPlayer;
	public float paddleAccel;
	public float paddleTopEnd;
	public float paddleSlow;
	public float paddleSpeedMultiplier;
	public float spinMultiplier;
	public float rotationMultiplier;
	public float spinDecay;



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
