using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTalkedTo : OnInteract {

    public string dialog = "...";

    public override void StartInteraction() {
        dialogBoxText.text = dialog;
        GameData.PlayerCanMove = true;
    }
}
