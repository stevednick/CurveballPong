using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {
	public float speed { get; set; }
	//public float momentum;
	//public float decay;
	public float accel;
	public Vector3 pos;
	public bool leftPressed { get; set; }
	public bool rightPressed { get; set; }
	public Rigidbody2D rb2d;
	Vector3 f = new Vector3(1, 0, 0);
	public Vector2 velocity;


	void Start()
	{
		leftPressed = false;
		rightPressed = false; 
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		if(leftPressed)
		{
			rb2d.AddForce (f * -accel);
				//momentum -= accel;
		}
		if (rightPressed) {
			rb2d.AddForce (f * accel);
			//momentum += accel;
		}

		velocity = rb2d.GetPointVelocity (new Vector2 (0, 0));

		/*
		Vector3 oldPos = transform.position;
		Vector3 newPos = new Vector3 (oldPos.x + momentum, oldPos.y, oldPos.z);
		transform.position = newPos;

		if (-decay < momentum && momentum < decay) {
			momentum = 0f;
		}

		if (momentum > 0f) {
			momentum -= decay;
		} else if (momentum < 0f) {
			momentum += decay;
		}
		*/
	}


}
