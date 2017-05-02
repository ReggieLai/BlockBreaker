using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallMove : Observable {
	public float speed;
	private int ballStarted = 0;
	public float force;
	private float maxSpeed = 200f;
	private string hitFloor = "Ball hit floor.";
	private GameManager gameManager;

	void Start() {
		observers = new List<Observer> ();
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		addObserver (gameManager);

	}


	// Moves the ball up when the spacebar key is pressed and only when the game has
	// just started, otherwise pressing the spacebar key has no effect.
	void FixedUpdate ()
	{
		if (Input.GetKeyDown (KeyCode.Space) && (ballStarted == 0)) {
			this.GetComponent<Rigidbody2D> ().AddForce (this.transform.up * 1.5f);
			ballStarted = ballStarted + 1;
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
			notifyObservers ();
		}
	}


	public override void notifyObservers () {
		foreach (Observer o in observers) {
			o.update (hitFloor);
		}
		
	}
		
}
		

