using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    
    [SerializeField]
    private GameObject playerCharacter;

    [SerializeField]
    private DialogHandler dialogHandler;

    private CharacterMover playerMover;

	// Use this for initialization
	void Start () {
        playerMover = playerCharacter.GetComponent<CharacterMover>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("e")) {
            if (GameData.DialogIsOpen) {
                dialogHandler.DisplayNextSentence();
            }
            else if (GameData.PlayerCanMove) {
                GameData.PlayerCanMove = false;
                Vector3 currentDirection = playerMover.GetCurrentDirection();
                RaycastHit2D raycast = Physics2D.Raycast(playerCharacter.transform.position + currentDirection, currentDirection, 0.1f);
                if (raycast.collider) {
                    if (raycast.collider.GetComponent<OnInteract>()) {
                        raycast.collider.gameObject.SendMessage("StartInteraction");
                    } else {
                        GameData.PlayerCanMove = true;
                    }
                } else {
                    GameData.PlayerCanMove = true;
                }
            }
        }
        else if (GameData.PlayerCanMove) {
            if (Input.GetKey("up") || Input.GetKey("w")) {               // UP
                playerMover.MoveUp();
            } else if (Input.GetKey("down") || Input.GetKey("s")) {      // DOWN
                playerMover.MoveDown();
            } else if (Input.GetKey("left") || Input.GetKey("a")) {      // LEFT
                playerMover.MoveLeft();
            } else if (Input.GetKey("right") || Input.GetKey("d")) {     // RIGHT
                playerMover.MoveRight();
            }
        }
    }
}
