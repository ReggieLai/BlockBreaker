using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, Observer {
	private static BallMove ball;
	private static Text statusText;
	private int lives;
	private string hitFloorEvent = "Ball hit floor.";
	private string gameOverEvent = "Game Over!";


	// Use this for initialization
	void Start () {
		statusText = GetComponent<Text> ();
		lives = 3;

	}
	
	// Update is called once per frame
	void Update () {
		checkGameOver ();
		
	}

	// Checks if the number of lives is 0.
	void checkGameOver() {
		if (lives == 0) {
			update("Game Over!");
		}
	}


	public void update(string msg) {

		if (msg.Equals (gameOverEvent)) {
			//do something
		}

		if (msg.Equals (hitFloorEvent)) {
			lives = lives - 1;
			statusText.text = "Lives: " + lives;
		}

	}
}
