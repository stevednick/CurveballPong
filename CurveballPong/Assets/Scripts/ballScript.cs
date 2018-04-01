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
	public Text smashText;
	public float smashSensitivity;


	// Use this for initialization
	void Start () {

		//angle = 170f;
		reset();
		spinDecay = 1.01f;
		rb2d = GetComponent<Rigidbody2D> ();
		smashOn = true;
		
	}


	void FixedUpdate(){

		smashCheck ();
		if (transform.localPosition.y < -300) {
			reset ();
			events.GetComponent<scoring> ().score (true);
		} else if (transform.localPosition.y > 300) {
			reset ();
			events.GetComponent<scoring> ().score (false);

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
			angle -= (c.gameObject.transform.localPosition.x - transform.localPosition.x) * paddleCurve;
			angle = -angle;
			spin += c.GetComponent<Rigidbody2D> ().velocity.x;


		}
		if (c.gameObject.tag == "bottom") {
			if (c.gameObject.transform.localPosition.y < transform.localPosition.y - ballRad) {
				angle += (c.gameObject.transform.localPosition.x - transform.localPosition.x) * paddleCurve;
				angle = -angle;
				spin -= c.GetComponent<Rigidbody2D> ().velocity.x;
			}

		}
		if (c.gameObject.tag == "topCol") {
			reset ();
		}
	}
	public Vector2 Vector2FromAngle(float a)
	{
		a *= Mathf.Deg2Rad;
		return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
	}

	public void smash(){
		if (smashOn) {
			angle = Random.Range (60, 120);
			spin = 0f;
		}
	}

	void smashCheck(){
		if ((angle % 360f > -smashSensitivity && angle % 360f < smashSensitivity) || (angle % 360f > 180f - smashSensitivity && angle % 360f < 180f + smashSensitivity)) {
			if (!smashOn) {
				smashText.color = Color.white;
				smashOn = true;
			}
		} else {
			if (smashOn) {
				smashText.color = Color.black;
				smashOn = false;
			}
		}
	}

}
