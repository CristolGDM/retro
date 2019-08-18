using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTalkedTo : OnInteract {

    public string dialog = "...";
    private Text textOnScreen;
    private Vector2 originalMaskPos;
    private bool dialogIsOpen = false;
    private GameObject dialogText;
    private GameObject dialogMask;
    private int dialogTransitionSpeed = 10;

    private void Start() {
        dialogText = GameObject.Find(ComponentNames.DialogText);
        dialogMask = GameObject.Find(ComponentNames.DialogMask);
    }

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

        originalMaskPos = dialogMask.GetComponent<Transform>().localPosition;
        Vector2 newMaskPos = new Vector2(0, -0.5f);
        dialogMask.GetComponent<UIMover>().MoveToNewPosition(newMaskPos, dialogTransitionSpeed);

        Invoke("DisplayNextSentence", 0.1f);
    }

    private void DisplayNextSentence() {
        dialogIsOpen = true;
        textOnScreen.text = dialog;
    }

    private void CloseDialog() {
        textOnScreen.text = "";
        dialogMask.GetComponent<UIMover>().MoveToNewPosition(originalMaskPos, dialogTransitionSpeed);
        dialogIsOpen = false;
        GameData.PlayerCanMove = true;
    }
}
