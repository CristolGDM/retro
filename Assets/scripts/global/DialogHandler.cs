﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogHandler : MonoBehaviour {
    [SerializeField]
    private Text dialogTextField;

    [SerializeField]
    private GameObject dialogMask;

    private List<string> dialog = new List<string> { "..." };
    private Vector2 originalMaskPos;
    private int dialogTransitionSpeed = 10;
    private int maxDialogLength = 95;
    private bool dialogIsOver;

    public void Start() {
        originalMaskPos = dialogMask.GetComponent<Transform>().localPosition;
    }

    public IEnumerator StartNewDialog(List<string> newDialog) {
        dialogTextField.text = "";
        dialogIsOver = false;
        GameData.DialogIsOpen = true;
        GameData.PlayerCanMove = false;

        Vector2 newMaskPos = new Vector2(0, -0.5f);
        dialogMask.GetComponent<UIMover>().MoveToNewPosition(newMaskPos, dialogTransitionSpeed);

        dialog = new List<string>(newDialog);
        DisplayNextSentence();

        while(!dialogIsOver) {
            yield return null;
        }

        CloseDialog();
        yield break;
    }

    public void DisplayNextSentence() {
        dialogTextField.text = "";
        Invoke("ReplaceSentence", 0.2f);
    }

    private void ReplaceSentence() {
        if (dialog.Count == 0) {
            dialogIsOver = true;
        }
        else {
            if (dialog[0].Length > maxDialogLength) {
                int lastSpace = dialog[0].Substring(0, maxDialogLength).LastIndexOf(" ", System.StringComparison.Ordinal);
                dialogTextField.text = dialog[0].Substring(0, lastSpace);
                dialog[0] = dialog[0].Substring(lastSpace + 1, dialog[0].Length - lastSpace - 1);
            } else {
                dialogTextField.text = dialog[0];
                dialog.RemoveAt(0);
            }
        }
    }

    private void CloseDialog() {
        dialogTextField.text = "";
        dialogMask.GetComponent<UIMover>().MoveToNewPosition(originalMaskPos, dialogTransitionSpeed);
        GameData.DialogIsOpen = false;
        GameData.PlayerCanMove = true;
    }
}
