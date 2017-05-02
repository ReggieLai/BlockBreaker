using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMove : MonoBehaviour {
	public float speed;


	// Update is called once per frame
	void FixedUpdate () {
		float direction = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
			transform.Translate(direction, 0, 0, Space.World);
		}

	}
}
