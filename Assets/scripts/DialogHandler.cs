using System.Collections;
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

    public void StartNewDialog(List<string> newDialog) {
        dialogTextField.text = "";
        GameData.DialogIsOpen = true;
        GameData.PlayerCanMove = false;

        originalMaskPos = dialogMask.GetComponent<Transform>().localPosition;
        Vector2 newMaskPos = new Vector2(0, -0.5f);
        dialogMask.GetComponent<UIMover>().MoveToNewPosition(newMaskPos, dialogTransitionSpeed);

        dialog = new List<string>(newDialog);
        Invoke("DisplayNextSentence", 0.1f);
    }

    public void DisplayNextSentence() {
        if (dialog.Count == 0) {
            CloseDialog();
        } else {
            dialogTextField.text = dialog[0];
            dialog.RemoveAt(0);
        }
    }

    private void CloseDialog() {
        dialogTextField.text = "";
        dialogMask.GetComponent<UIMover>().MoveToNewPosition(originalMaskPos, dialogTransitionSpeed);
        GameData.DialogIsOpen = false;
        GameData.PlayerCanMove = true;
    }
}
