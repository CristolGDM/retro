﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    
    [SerializeField]
    private GameObject playerCharacter = null;

    [SerializeField]
    private DialogHandler dialogHandler = null;

    [SerializeField]
    private MenuManager MenuManager = null;

    private CharacterMover playerMover;

	// Use this for initialization
	void Start () {
        playerMover = playerCharacter.GetComponent<CharacterMover>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameData.inputBypassedByEventManager) return;
        /* INTERACT KEY */
        if (InteractKeySingle()) {
            if (GameData.MenuIsOpen) {
                MenuManager.SelectCurrentOption();
            }
            else if (GameData.DialogIsOpen) {
                dialogHandler.DisplayNextSentence();
            } else if (GameData.PlayerCanMove) {
                GameData.PlayerCanMove = false;
                Vector3 currentDirection = playerMover.GetCurrentDirection();
                RaycastHit2D raycast = Physics2D.Raycast(playerCharacter.transform.position + currentDirection, currentDirection, 0.1f);
                if (raycast.collider) {
                    if (raycast.collider.GetComponent<OnInteract>()) {
                        raycast.collider.gameObject.SendMessage("StartInteraction");
                    } 
                }
                GameData.PlayerCanMove = true;
            }
        }
        /* UP KEY */
        else if (UpKey()) {
            if (GameData.PlayerCanMove) StartCoroutine(playerMover.MoveUp());
            else if (UpKeySingle()) {
                if (GameData.MenuIsOpen) MenuManager.MoveUp();
            }
        }

        /* DOWN KEY */
        else if (DownKey()) {
            if (GameData.PlayerCanMove) StartCoroutine(playerMover.MoveDown());
            else if (DownKeySingle()) {
                if (GameData.MenuIsOpen)MenuManager.MoveDown();
            }
        }

        /* LEFT KEY */
        else if (LeftKey()) {
            if (GameData.PlayerCanMove) StartCoroutine(playerMover.MoveLeft());
            else if (LeftKeySingle()) {
                if (GameData.MenuIsOpen) MenuManager.MoveLeft();
            }
        }

        /* RIGHT KEY */
        else if (RightKey()) {
            if (GameData.PlayerCanMove) StartCoroutine(playerMover.MoveRight());
            else if (RightKeySingle()) {
                if (GameData.MenuIsOpen) MenuManager.MoveRight();
            }
        }

        /* MENU KEY */
        else if (MenuKeySingle()) {
            if (!GameData.MenuIsOpen && GameData.PlayerCanMove) MenuManager.OpenMenu();
            else MenuManager.CloseAllMenus();
        }

        /* MENU KEY */
        else if (CancelKeySingle()) {
            if(GameData.MenuIsOpen) {
                MenuManager.GoBack();
            }
        }
    }

    private bool UpKey() {
        return Input.GetKey("up") || Input.GetKey("w");
    }
    private bool UpKeySingle() {
        return Input.GetKeyDown("up") || Input.GetKeyDown("w");
    }

    private bool DownKey() {
        return Input.GetKey("down") || Input.GetKey("s");
    }
    private bool DownKeySingle() {
        return Input.GetKeyDown("down") || Input.GetKeyDown("s");
    }

    private bool LeftKey() {
        return Input.GetKey("left") || Input.GetKey("a");
    }
    private bool LeftKeySingle() {
        return Input.GetKeyDown("left") || Input.GetKeyDown("a");
    }

    private bool RightKey() {
        return Input.GetKey("right") || Input.GetKey("d");
    }
    private bool RightKeySingle() {
        return Input.GetKeyDown("right") || Input.GetKeyDown("d");
    }

    private bool InteractKey() {
        return Input.GetKey("e");
    }
    private bool InteractKeySingle() {
        return Input.GetKeyDown("e");
    }

    private bool MenuKey() {
        return Input.GetKey("enter") || Input.GetKey("return");
    }
    private bool MenuKeySingle() {
        return Input.GetKeyDown("enter") || Input.GetKeyDown("return");
    }

    private bool CancelKey() {
        return Input.GetKey("escape") || Input.GetKey("q");
    }
    private bool CancelKeySingle() {
        return Input.GetKeyDown("escape") || Input.GetKeyDown("q");
    }
}
