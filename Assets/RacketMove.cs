using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMove : MonoBehaviour, Observer {
	public float speed;
	private float direction;
	private bool canMove;
    private bool floorHit = false;
	public int leftEdge;
	public int rightEdge;


	// Update is called once per frame
	void FixedUpdate () {
		direction = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

		if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && canMove) {
			transform.Translate(direction, 0, 0, Space.World);
            
		} 

        // out of bounds
		if ((((this.transform.position.x < leftEdge) && Input.GetKey (KeyCode.LeftArrow)) || ((this.transform.position.x > rightEdge) && Input.GetKey (KeyCode.RightArrow))) || floorHit) {
			canMove = false;
		} else {
			canMove = true;
		}
			

	}

    public void stopRacket()
    {
        canMove = false;
        floorHit = true;
    }

    public void resetRacket()
    {
        floorHit = false;
    }


    public void update(bool hitFloor)
    {
        if (hitFloor)
        {
            floorHit = true;
            canMove = false;
        }

    }

}
