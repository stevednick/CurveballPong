using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAreaScript : MonoBehaviour {

	List<string> numbers = new List<string> ();
	public Text top;
	public Text bottom;
	int topScore = 0;
	int bottomScore = 0;

	// Use this for initialization
	void Start () {

		sortNumbers ();
		if (dataController.DC.twoPlayer) {
			top.transform.Rotate (Vector3.forward * 180);
		}

	}

	void display(){

		//top.text = numbers [topScore];
		//bottom.text = numbers [bottomScore];
		top.text = "" + topScore;
		bottom.text = "" + bottomScore;
	}

	public void score(bool top){
		if (top) {
			topScore += 1;
		} else if (!top) {
			bottomScore += 1;
		}
		if(topScore == 11 || bottomScore == 11){
			SceneManager.LoadScene(2);
		}
		display ();
	}

	void sortNumbers(){
		numbers.Add ("zero");
		numbers.Add ("one");
		numbers.Add ("two");
		numbers.Add ("three");
		numbers.Add ("four");
		numbers.Add ("five");
		numbers.Add ("six");
		numbers.Add ("seven");
		numbers.Add ("eight");
		numbers.Add ("nine");
		numbers.Add ("ten");
		numbers.Add ("eleven");
		display ();
	}
}
