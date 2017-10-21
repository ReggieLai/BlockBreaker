using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//initializeColour ();
	}

	// Randomize brick colour. 
	public void initializeColour() {
		GetComponent<SpriteRenderer> ().color = Random.ColorHSV (0f, 1f, 1f, 1f, 0.5f, 1f);
	}
}
