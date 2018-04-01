using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computerScript : MonoBehaviour {

	public GameObject ball;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 newPos = new Vector3 (ball.transform.position.x + 0.3f, transform.position.y, transform.position.z);
		transform.position = newPos;
		
	}


}
