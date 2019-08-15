﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMover))]
public class PlayerMovement : MonoBehaviour {
    private CharacterMover mover;
    private Animator animator;

	// Use this for initialization
	void Start () {
        mover = GetComponent<CharacterMover>();
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("e") && GameData.PlayerCanMove) {
            GameData.PlayerCanMove = false;
            Vector3 currentDirection = mover.GetCurrentDirection();
            RaycastHit2D raycast = Physics2D.Raycast(transform.position + currentDirection, currentDirection, 0.1f);
            if (raycast.collider) {
                if(raycast.collider.GetComponent<OnInteract>()) {
                    raycast.collider.gameObject.SendMessage("StartInteraction");
                }
                else {
                    GameData.PlayerCanMove = true;
                }
            }
            else {
                GameData.PlayerCanMove = true;
            }
        }
        if (GameData.PlayerCanMove) {
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
}
