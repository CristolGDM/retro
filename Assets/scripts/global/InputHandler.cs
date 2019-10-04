using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    
    [SerializeField]
    private GameObject playerCharacter;

    [SerializeField]
    private DialogHandler dialogHandler;

    [SerializeField]
    private MenuManager MenuManager;

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
            else if (GameData.MenuIsOpen) {
                MenuManager.SelectCurrentOption();
            }
        }
        /* UP KEY */
        else if (Input.GetKey("up") || Input.GetKey("w")) {
            if (GameData.PlayerCanMove) playerMover.MoveUp();
            else if (Input.GetKeyDown("up") || Input.GetKeyDown("w")) {
                if (GameData.MenuIsOpen) MenuManager.MoveUp();
            }
        }

        /* DOWN KEY */
        else if (Input.GetKey("down") || Input.GetKey("s")) {
            if (GameData.PlayerCanMove) playerMover.MoveDown();
            else if (Input.GetKeyDown("down") || Input.GetKeyDown("s")) {
                if (GameData.MenuIsOpen)MenuManager.MoveDown();
            }
        }

        /* LEFT KEY */
        else if (Input.GetKey("left") || Input.GetKey("a")) {
            if (GameData.PlayerCanMove) playerMover.MoveLeft();
            else if (Input.GetKeyDown("left") || Input.GetKeyDown("a")) {
                if (GameData.MenuIsOpen) MenuManager.MoveLeft();
            }
        }

        /* RIGHT KEY */
        else if (Input.GetKey("right") || Input.GetKey("d")) {
            if (GameData.PlayerCanMove) playerMover.MoveRight();
            else if (Input.GetKeyDown("right") || Input.GetKeyDown("d")) {
                if (GameData.MenuIsOpen) MenuManager.MoveRight();
            }
        }

        /* MENU KEY */
        else if (Input.GetKeyDown("enter") || Input.GetKeyDown("return")) {
            if (!GameData.MenuIsOpen && GameData.PlayerCanMove) MenuManager.OpenMenu();
            else MenuManager.CloseMenu();
        }

    }
}
