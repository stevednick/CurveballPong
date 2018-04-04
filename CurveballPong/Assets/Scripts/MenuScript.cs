using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	public Text playerText;

	public void changePlayers(){
		dataController.DC.switchPlayers();
		if (dataController.DC.twoPlayer) {
			playerText.text = "two player";
		} else {
			playerText.text = "one player";
		}
	}
}
