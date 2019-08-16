using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTalkedTo : OnInteract {

    public string dialog = "...";

    public override void StartInteraction() {
        dialogBoxText.GetComponent<Text>().text = dialog;
        Debug.Log(dialogBoxBackground.GetComponent<RectTransform>().rect.height);
        GameData.PlayerCanMove = true;
    }
}
