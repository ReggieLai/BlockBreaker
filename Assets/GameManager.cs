using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, Observer {
	private static BallMove ball;
	private Vector2 ballInitialPos;
	private static RacketMove leftRacket;
	private static RacketMove middleRacket;
	private static RacketMove rightRacket;
	private Vector2 leftRacketInitialPos;
	private Vector2 middleRacketInitialPos;
	private Vector2 rightRacketInitialPos;
	private static GameObject ballRestartPanel;
	private static Text statusText;
	private int lives;
	private bool hitFloorEvent;
	private bool gameOverEvent;


	// Use this for initialization
	void Start () {
		ball = GameObject.FindGameObjectWithTag("ball").GetComponent<BallMove>();
		leftRacket = GameObject.Find("leftRacket").GetComponent<RacketMove> ();
		middleRacket = GameObject.Find("middleRacket").GetComponent<RacketMove> ();
		rightRacket = GameObject.Find("rightRacket").GetComponent<RacketMove> ();
		ballInitialPos = ball.transform.position;
		leftRacketInitialPos = leftRacket.transform.position;
		middleRacketInitialPos = middleRacket.transform.position;
		rightRacketInitialPos = rightRacket.transform.position;
	
		ballRestartPanel = GameObject.Find ("Panel");
		ballRestartPanel.SetActive (false);
		statusText = GetComponent<Text> ();
		lives = 3;

		hitFloorEvent = false;
		gameOverEvent = false;

	}
	
	// Update is called once per frame
	void Update () {
		checkGameOver ();

		if (hitFloorEvent && Input.GetKeyDown(KeyCode.Space))
			resetBall ();

		
	}

	// Checks if the number of lives is 0.
	void checkGameOver() {
		if (lives == 0) {
			//update("Game Over!");
		}
	}

	void resetBall() {
		ball.transform.position = ballInitialPos;
		leftRacket.transform.position = leftRacketInitialPos;
		middleRacket.transform.position = middleRacketInitialPos;
		rightRacket.transform.position = rightRacketInitialPos;

		ball.resetBallState ();
		ballRestartPanel.SetActive (false);

	}


	public void update(bool hitFloor) {
		if (hitFloor) {
			if (lives >= 1) {
				lives = lives - 1;
				statusText.text = "Lives: " + lives;
				ballRestartPanel.SetActive (true);
			}
			hitFloorEvent = true;
				
		}

	}
}
