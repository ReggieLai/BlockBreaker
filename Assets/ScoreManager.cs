using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour, Observer {
	private static Text scoreText;
	private float time;
	private GameManager gameManager;
	private BallMove ball;
	private bool gamePaused;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.FindGameObjectWithTag ("ScoreManager").GetComponent<Text> ();
		gameManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ();
		ball = GameObject.FindGameObjectWithTag ("ball").GetComponent<BallMove> ();
		gamePaused = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!gamePaused.Equals(true) && ball.ballMoving()) {
			time += Time.deltaTime;
			scoreText.text = "Time: " + time;
		}
			

		if (gameManager.hitFloor () && Input.GetKeyDown (KeyCode.Space)) {
			gamePaused = false;
			time += Time.deltaTime;
			scoreText.text = "Time: " + time;
		}
			
	}

    public void setPause()
    {
        gamePaused = true;
    }

	public void update(bool hitFloor) {
		if (hitFloor) {
			gamePaused = true;
		}
	}
}
