using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallMove : Observable {
	public float speed;
	private bool ballStarted;
	public float force;
	private float maxSpeed = 200f;
	private bool hitFloor;
	private GameManager gameManager;

	void Start() {
		ballStarted = false;
		hitFloor = false;
		observers = new List<Observer> ();
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		addObserver (gameManager);

	}


	// Moves the ball up when the spacebar key is pressed and only when the game has
	// just started, otherwise pressing the spacebar key has no effect.
	void FixedUpdate ()
	{
		if (Input.GetKeyDown (KeyCode.Space) && (ballStarted == false)) {
			this.GetComponent<Rigidbody2D> ().AddForce (this.transform.up * 1.5f);
			ballStarted = true;
		}

		if (this.GetComponent<Rigidbody2D> ().velocity.magnitude > maxSpeed) {
			this.GetComponent<Rigidbody2D> ().velocity = this.GetComponent<Rigidbody2D> ().velocity.normalized * maxSpeed;
		}
			
	}

	// Ball moves left if it hits the left-side of the racket, moves right if it hits the
	// right-side of the racket.
	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.name == "leftRacket") {
			Vector2 dir = new Vector2(-1f, 0.5f) * Time.deltaTime * force;
			this.GetComponent<Rigidbody2D>().AddForce(dir);
		}

		if (coll.gameObject.name == "rightRacket") {
			Vector2 dir = new Vector2(1f, 0.5f) * Time.deltaTime * force;
			this.GetComponent<Rigidbody2D>().AddForce(dir);
		}

		if (coll.gameObject.name == "bottom_wall") {
			stopBall ();
			hitFloor = true;
			notifyObservers ();
		}
	}

	// Ball stops moving.
	public void stopBall() {
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
	}

	public void resetBallState() {
		ballStarted = false;
	}


	public override void notifyObservers () {
		foreach (Observer o in observers) {
			o.update (hitFloor);
		}
		
	}
		
}
		

