using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTalkedTo : OnInteract {

    public string dialog = "...";

    public override void StartInteraction() {
        Debug.Log(dialog);
        GameData.PlayerCanMove = true;
    }
}
