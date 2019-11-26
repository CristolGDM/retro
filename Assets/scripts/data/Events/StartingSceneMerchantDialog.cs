using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSceneMerchantDialog : EventTrigger {

    public override IEnumerator StartInteraction() {
        DisableMovingThis();
        DisablePlayerMovement();
        TurnTowardPlayer();
        yield return StartCoroutine(StartDialog(new List<string>{
            "\"Hello there boy\"",
            "\"Wanna buy some stuff?\""
        }));
        EnableMovingThis();
        EnablePlayerMovement();
    }
}
