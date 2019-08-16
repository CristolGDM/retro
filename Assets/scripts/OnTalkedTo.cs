using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTalkedTo : OnInteract {

    public string dialog = "...";
    private RectTransform dialogBgRect;
    private RectTransform dialogTextRect;
    private Text textOnScreen;
    private Vector2 newBgPos;
    private Vector2 newTxtPos;

    ///////////////////////////////////////

    public override void StartInteraction() {
        StartDialog();
    }

    private void StartDialog() {
        dialogBgRect = dialogBoxBackground.GetComponent<RectTransform>();
        newBgPos = new Vector2(dialogBgRect.position.x, (dialogBgRect.rect.height / 2));

        dialogBoxBackground.GetComponent<UIMover>().MoveToNewPosition(newBgPos);

        //textOnScreen.text = dialog;
    }
}
