using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {
	private float speed { get; set; }
	public float accel;
	public Vector3 pos;
	public bool leftPressed { get; set; }
	public bool rightPressed { get; set; }
	private Rigidbody2D rb2d;
	Vector3 f = new Vector3(1, 0, 0);
	public Vector2 velocity;
	public GameObject ball;
	public float computerSensivity;

	void Start()
	{
		leftPressed = false;
		rightPressed = false; 
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		if (gameObject.tag == "top") {

			if (ball.GetComponent<Rigidbody2D> ().velocity.y > 0f) {
				if (transform.localPosition.x > ball.transform.localPosition.x - computerSensivity) {
					leftPressed = true;
					if (rightPressed) {
						rightPressed = false;
					}
				}
				if (transform.localPosition.x < ball.transform.localPosition.x + computerSensivity) {
					rightPressed = true;
					if (leftPressed) {
						leftPressed = false;
					}
				}
			} else {
				leftPressed = false;
				rightPressed = false;
			}
		}

		if(leftPressed)
		{
			rb2d.AddForce (f * -accel);
				//momentum -= accel;
		}
		if (rightPressed) {
			rb2d.AddForce (f * accel);
			//momentum += accel;
		}


	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.tag == "wall") {
			rb2d.velocity = new Vector2 ((-rb2d.velocity.x * 0.2f), 0);
		}

	}

	void OnTriggerStay2D(Collider2D c){
		if (transform.position.x < 0) {
			leftPressed = false;
		} else if (transform.position.x > 0) {
			rightPressed = false;
		}
	}
}
