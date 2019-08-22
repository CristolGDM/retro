using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    
    [SerializeField]
    private GameObject playerCharacter;

    [SerializeField]
    private DialogHandler dialogHandler;

    [SerializeField]
    private MenuManager menuManager;

    private CharacterMover playerMover;

	// Use this for initialization
	void Start () {
        playerMover = playerCharacter.GetComponent<CharacterMover>();
	}
	
	// Update is called once per frame
	void Update () {
        /* INTERACT KEY */
        if (Input.GetKeyDown("e")) {
            if (GameData.DialogIsOpen) {
                dialogHandler.DisplayNextSentence();
            } else if (GameData.PlayerCanMove) {
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
        /* UP KEY */
        else if (Input.GetKey("up") || Input.GetKey("w")) {
            if (GameData.PlayerCanMove) playerMover.MoveUp();
        }

        /* DOWN KEY */
        else if (Input.GetKey("down") || Input.GetKey("s")) {
            if (GameData.PlayerCanMove) playerMover.MoveDown();
        }

        /* LEFT KEY */
        else if (Input.GetKey("left") || Input.GetKey("a")) {
            if (GameData.PlayerCanMove) playerMover.MoveLeft();
        }

        /* RIGHT KEY */
        else if (Input.GetKey("right") || Input.GetKey("d")) {
            if (GameData.PlayerCanMove) playerMover.MoveRight();
        }

        /* MENU KEY */
        else if (Input.GetKeyDown("enter") || Input.GetKeyDown("return")) {
            if (!GameData.MenuIsOpen && GameData.PlayerCanMove) menuManager.openMenu();
            else menuManager.closeMenu();
        }

    }
}
