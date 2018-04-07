using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

	public float speed;
	public float speedMultiplier;
	public float accel;
	public float maxSpeed;
	public float topEnd;
	public float slow;
	public Vector3 pos;
	public bool leftPressed { get; set; }
	public bool rightPressed { get; set; }
	private Rigidbody2D rb2d;
	Vector3 f = new Vector3(1, 0, 0);
	public Vector2 velocity;
	public GameObject ball;
	public float computerSensivity;
	public bool twoPlayer = false;

	public GameObject canvas;
	float screenWidth;
	float screenHeight;

	public float paddleWidth;



	void Start()
	{
		
		leftPressed = false;
		rightPressed = false; 
		rb2d = GetComponent<Rigidbody2D> ();

		accel = dataController.DC.paddleAccel;
		maxSpeed = 1f;
		topEnd = dataController.DC.paddleTopEnd;
		slow = dataController.DC.paddleSlow;
		topEnd = dataController.DC.paddleTopEnd;
		speedMultiplier = dataController.DC.paddleSpeedMultiplier;

		RectTransform objectRectTransform = canvas.GetComponent<RectTransform> ();
		screenWidth = objectRectTransform.rect.width;
		screenHeight = objectRectTransform.rect.height;
	}

	void Update ()
	{
		
		if (gameObject.tag == "top" && !dataController.DC.twoPlayer) {

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

		control ();
		move ();
		/*
		if(leftPressed)
		{
			rb2d.AddForce (f * -accel);
				//momentum -= accel;
		}
		if (rightPressed) {
			rb2d.AddForce (f * accel);
			//momentum += accel;
		}
		*/


	}

	void move(){

		if (leftPressed) {
			if (speed > -maxSpeed) {
				speed -= accel;
			} else if (speed <= -maxSpeed) {
				speed -= topEnd;
			}
		} else if (rightPressed) {
			if (speed < maxSpeed) {
				speed += accel;
			} else if (speed >= maxSpeed) {
				speed += topEnd;
			}
		} else {
			speed = speed / slow;
		}
		Vector3 pos = transform.localPosition;
		pos = new Vector3 (pos.x + (speed * speedMultiplier * Time.deltaTime), pos.y, pos.z);

		if (pos.x - paddleWidth < -screenWidth / 2f) {
			pos.x -= (pos.x - paddleWidth + screenWidth / 2f) / 4f;
		} else if (pos.x + paddleWidth > screenWidth / 2f) {
			pos.x -= (pos.x + paddleWidth - screenWidth / 2f) / 4f;
		}
			
		transform.localPosition = pos;
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.tag == "wall") {
			rb2d.velocity = new Vector2 ((-rb2d.velocity.x * 0.2f), 0);
		}

	}

	void OnTriggerStay2D(Collider2D c){

		if (c.gameObject.tag == "wall") {
			if (transform.position.x < 0) {
				leftPressed = false;
			} else if (transform.position.x > 0) {
				rightPressed = false;
			}
		}
	}

	void control(){
		
		if(Input.GetButtonDown("Horizontal")){
			leftPressed = true;
		}
		if (Input.GetButtonUp ("Horizontal")) {
			leftPressed = false;
		}
		if(Input.GetButtonDown("Vertical")){
			rightPressed = true;
		}
		if (Input.GetButtonUp ("Vertical")) {
			rightPressed = false;
		}
		if (Input.GetButtonDown ("Fire1")) {
			ball.GetComponent<ballScript> ().smash (false);
		}
	}
		
}
