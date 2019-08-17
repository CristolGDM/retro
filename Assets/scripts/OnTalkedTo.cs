using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTalkedTo : OnInteract {

    public string dialog = "...";
    private Text textOnScreen;
    private Vector2 originalBgPos;
    private bool dialogIsOpen = false;

    private void Update() {
        if (Input.GetKeyDown("e") && dialogIsOpen) {
            CloseDialog();
        }
    }

    ///////////////////////////////////////

    public override void StartInteraction() {
        StartDialog();
    }

    private void StartDialog() {
        textOnScreen = dialogText.GetComponent<Text>();
        textOnScreen.text = "";

        originalBgPos = dialogBox.GetComponent<Transform>().localPosition;
        Vector2 newBgPos = new Vector2(-0.5f, -1.0f);
        dialogBox.GetComponent<UIMover>().MoveToNewPosition(newBgPos);

        Invoke("DisplayNextSentence", 0.2f);
    }

    private void DisplayNextSentence() {
        dialogIsOpen = true;
        textOnScreen.text = dialog;
    }

    private void CloseDialog() {
        textOnScreen.text = "";
        dialogBox.GetComponent<UIMover>().MoveToNewPosition(originalBgPos);
        dialogIsOpen = false;
        GameData.PlayerCanMove = true;
    }
}
