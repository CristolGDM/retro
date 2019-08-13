using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMover))]
public class PlayerMovement : MonoBehaviour {
    private CharacterMover mover;

	// Use this for initialization
	void Start () {
        mover = GetComponent<CharacterMover>();
	}

    // Update is called once per frame
    void Update() {

        if (Input.GetKey("up") || Input.GetKey("w")) {               // UP
            mover.MoveUp();
        } else if (Input.GetKey("down") || Input.GetKey("s")) {      // DOWN
            mover.MoveDown();
        } else if (Input.GetKey("left") || Input.GetKey("a")) {      // LEFT
            mover.MoveLeft();
        } else if (Input.GetKey("right") || Input.GetKey("d")) {     // RIGHT
            mover.MoveRight();
        } else {
            mover.StopMoving();
        }
    }
}
