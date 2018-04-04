using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballScript : MonoBehaviour {

	Rigidbody2D rb2d;
	public float paddleCurve;
	private float currentSpeed;
	public float speedIncrease;
	public float startSpeed;
	public float spin;
	public float spinMultiplier = 0.01f;
	public float spinDecay;
	public float angle; 
	public float rotationMultiplier;
	float ballRad = 1;
	public GameObject events;
	public bool smashOn;
	public Button topSmash;
	public Button bottomSmash;
	public float smashSensitivity;
	public GameObject topPaddle;
	public GameObject bottomPaddle;
	public bool touchingTop;
	public bool touchingBottom;


	// Use this for initialization
	void Start () {

		//angle = 170f;
		reset();
		spinDecay = 1.01f;
		rb2d = GetComponent<Rigidbody2D> ();
		smashOn = true;
		touchingTop = false;
		touchingBottom = false;
		
	}


	void FixedUpdate(){

		smashCheck ();
		if (transform.localPosition.y < -300) {
			reset ();
			events.GetComponent<PlayAreaScript> ().score (true);
		} else if (transform.localPosition.y > 300) {
			reset ();
			events.GetComponent<PlayAreaScript> ().score (false);

		}
		angle -= spin * spinMultiplier;
		spin = spin / spinDecay;
		rb2d.velocity = Vector2FromAngle (angle) * currentSpeed;
		transform.Rotate(Vector3.forward * (-spin * rotationMultiplier));

	}

	public void reset(){
		transform.localPosition = new Vector3 (0, 0, 0);
		spin = 0f;
		currentSpeed = startSpeed;
		angle = 40f;
	}

	void OnTriggerEnter2D(Collider2D c){

		currentSpeed += 0.2f;
		if (c.gameObject.tag == "wall") {
			angle = 180f - angle;
		}

		if (c.gameObject.tag == "top") {
			touchingTop = true;
		}
		if (c.gameObject.tag == "bottom") {
			touchingBottom = true;
		}
		if (c.gameObject.tag == "topCol" && touchingTop) {
			angle -= (topPaddle.transform.localPosition.x - transform.localPosition.x) * paddleCurve;
			angle = -angle;
			spin += topPaddle.GetComponent<Rigidbody2D> ().velocity.x;
			Debug.Log ("This");


		}
		if (c.gameObject.tag == "bottomCol" && touchingBottom) { //Ooh Err! 

			angle += (bottomPaddle.transform.localPosition.x - transform.localPosition.x) * paddleCurve;
			angle = -angle;
			spin -= bottomPaddle.GetComponent<Rigidbody2D> ().velocity.x;
		

		}

	}

	void OnTriggerExit2D(Collider2D c){

		if (c.gameObject.tag == "top") {
			touchingTop = false;
		}
		if (c.gameObject.tag == "bottom") {
			touchingBottom = false;
		}

	}

	public Vector2 Vector2FromAngle(float a)
	{
		a *= Mathf.Deg2Rad;
		return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
	}

	public void smash(bool top){
		if (!top) {
			angle = Random.Range (60, 120);
		} else if (top) {
			angle = Random.Range (240, 300);
		}
		spin = 0f;
		currentSpeed += speedIncrease * 2f;
	}

	void smashCheck(){
		bottomSmash.gameObject.SetActive (false);
		bottomSmash.interactable = false;
		topSmash.gameObject.SetActive (false);
		topSmash.interactable = false;

		if(angleCheck()){
			
			if (transform.localPosition.y > 0f) {
				topSmash.gameObject.SetActive (true);
				topSmash.interactable = true;
			} else {
				bottomSmash.gameObject.SetActive (true);
				bottomSmash.interactable = true;
			}
		}
	}

	bool angleCheck(){
		while (angle < 0f) {
			angle += 360f;
		}

		if (angle % 360f < smashSensitivity) {
			return true;
		} else if ((angle % 360f) > 360f - smashSensitivity) {
			return true;
		} else if (angle % 360f > 180f - smashSensitivity && angle % 360f < 180f + smashSensitivity) {
			return true;
		} else {
			return false;
		}
	}

}
