using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : Observable {
	private GameManager gameManager;
	private BallMove ball;
	private ScoreManager scoreManager;
	private bool hitFloor;

	// Use this for initialization
	void Start () {
		observers = new List<Observer> ();
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		ball = GameObject.FindGameObjectWithTag("ball").GetComponent<BallMove>();
		scoreManager = GameObject.FindGameObjectWithTag ("ScoreManager").GetComponent<ScoreManager> ();
		hitFloor = false;
		addObserver (gameManager);
		addObserver (ball);
		addObserver (scoreManager);
	}

	// If collides with ball, notify observers.
	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "ball") {
			hitFloor = true;
			notifyObservers ();
	
		}
	}

	public override void notifyObservers () {
		foreach (Observer o in observers) {
			o.update (hitFloor);
		}

	}
}
