using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTalkedTo : OnInteract {

    public string dialog = "...";
    private Text textOnScreen;
    private RectTransform dialogBgRect;
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
        textOnScreen = dialogBoxText.GetComponent<Text>();
        textOnScreen.text = "";
        dialogBgRect = dialogBoxBackground.GetComponent<RectTransform>();

        originalBgPos = dialogBgRect.position;
        Vector2 newBgPos = new Vector2(dialogBgRect.position.x, (dialogBgRect.rect.height / 2));
        dialogBoxBackground.GetComponent<UIMover>().MoveToNewPosition(newBgPos);

        Invoke("DisplayNextSentence", 0.3f);
    }

    private void DisplayNextSentence() {
        dialogIsOpen = true;
        textOnScreen.text = dialog;
    }

    private void CloseDialog() {
        textOnScreen.text = "";
        dialogBoxBackground.GetComponent<UIMover>().MoveToNewPosition(originalBgPos);
        dialogIsOpen = false;
        GameData.PlayerCanMove = true;
    }
}
