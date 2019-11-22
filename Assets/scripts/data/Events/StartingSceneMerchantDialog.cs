using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSceneMerchantDialog : EventTrigger {

    public override void StartInteraction() {
        DisableMoving();
        TurnTowardPlayer();
        StartDialog(new List<string>{
            "Hello there boy",
            "Wanna buy some stuff?"
        });
        EnableMoving();
    }
}
