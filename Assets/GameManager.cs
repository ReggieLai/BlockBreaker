using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, Observer {
	private static BallMove ball;
	private Vector2 ballInitialPos;
	private Transform bar;
	private static RacketMove leftRacket;
	private static RacketMove middleRacket;
	private static RacketMove rightRacket;
	private Vector2 leftRacketInitialPos;
	private Vector2 middleRacketInitialPos;
	private Vector2 rightRacketInitialPos;
	private static GameObject ballRestartPanel;
	private static GameObject gameOverPanel;
    private static GameObject winPanel;
	private static Text statusText;
	private int lives;
	private static bool hitFloorEvent;
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
		bar = GameObject.Find ("middleRacket").transform;
	
		ballRestartPanel = GameObject.Find ("RestartPanel");
		ballRestartPanel.SetActive (false);

		gameOverPanel = GameObject.Find ("GameOverPanel");
		gameOverPanel.SetActive (false);

        winPanel = GameObject.Find("WinPanel");
        winPanel.SetActive(false);

        statusText = GetComponent<Text> ();
		lives = 3;

		hitFloorEvent = false;
		gameOverEvent = false;

	}
	
	// Checks if game is over and call to reset the ball and racket when the game starts again.
	void Update () {

		if (hitFloorEvent && Input.GetKeyDown(KeyCode.Space))
        {
            resetBall();
            resetRacket();
        }
			

		if (ball.ballMoving().Equals (false)) {
			ball.transform.position = new Vector2 (bar.position.x, ball.transform.position.y);

		}

        maybeWin();
			
		
	}

	// Checks if the number of bricks is 0.
	void maybeWin() {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("brick");
        if (bricks.Length == 0)
        {
            ball.stopBall();
            leftRacket.stopRacket();
            middleRacket.stopRacket();
            rightRacket.stopRacket();
            ScoreManager scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager> ();
            scoreManager.setPause();

            Text text = winPanel.GetComponentInChildren<Text>();
            text.text = "Congratulations! You beat this level in " + scoreManager.getTime().ToString() + " seconds.";
            winPanel.SetActive(true);
        }
	}




    // Re-positions ball and racket to center of screen. 
    void resetBall() {
		ball.transform.position = ballInitialPos;
		leftRacket.transform.position = leftRacketInitialPos;
		middleRacket.transform.position = middleRacketInitialPos;
		rightRacket.transform.position = rightRacketInitialPos;
		hitFloorEvent = false;

		ball.resetBallState ();
		ballRestartPanel.SetActive (false);

	}

    void resetRacket()
    {
        leftRacket.resetRacket();
        middleRacket.resetRacket();
        rightRacket.resetRacket();
    }

	// Returns if ball has touched the floor.
	public bool hitFloor() {
		return hitFloorEvent;
	}


	public void update(bool hitFloor) {
		if (hitFloor) {
			if (lives > 1) {
                if (ballRestartPanel != null)
                {
                    print("restart panel not null");
                }
				ballRestartPanel.SetActive (true);
                print("game manager set restart panel true");
			} else {
				gameOverPanel.SetActive (true);
                
			}

			lives = lives - 1;
			statusText.text = "Lives: " + lives;
			hitFloorEvent = true;
				
		}

	}
}
