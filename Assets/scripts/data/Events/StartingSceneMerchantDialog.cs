using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSceneMerchantDialog : EventTrigger {

    public override IEnumerator StartInteraction() {
        DisableMovingThis();
        DisablePlayerMovement();
        TurnTowardPlayer();
        ShowDialogBackground();
        yield return StartCoroutine(StartDialog(new List<string>{
            "\"Hello there boy\"",
            "\"Wanna see me dance?\""
        }));
        yield return StartCoroutine(MoveMeUp());
        HideDialogBackground();
        EnableMovingThis();
        EnablePlayerMovement();
    }
}
