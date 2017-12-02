using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : Observable {
	private GameManager gameManager;
	private BallMove ball;
    private RacketMove leftRacket;
    private RacketMove middleRacket;
    private RacketMove rightRacket;
	private ScoreManager scoreManager;
	private bool hitFloor;

    // Use this for initialization
    new void Start () {
		observers = new List<Observer> ();
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		ball = GameObject.FindGameObjectWithTag("ball").GetComponent<BallMove>();
        leftRacket = GameObject.Find("leftRacket").GetComponent<RacketMove>();
        middleRacket = GameObject.Find("middleRacket").GetComponent<RacketMove>();
        rightRacket = GameObject.Find("rightRacket").GetComponent<RacketMove>();
        scoreManager = GameObject.FindGameObjectWithTag ("ScoreManager").GetComponent<ScoreManager> ();
		hitFloor = false;
		addObserver (gameManager);
		addObserver (ball);
		addObserver (scoreManager);
        addObserver(leftRacket);
        addObserver(middleRacket);
        addObserver(rightRacket);
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
