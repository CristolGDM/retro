using System.Collections;
using System.Collections.Generic;

public class StartingSceneMerchantDialog : EventTrigger {

    public override IEnumerator StartInteraction() {
        DisableMovingThis();
        DisablePlayerMovement();
        TurnTowardPlayer();
        ShowDialogBackground();
        yield return StartDialog(new List<string>{
            "\"Hello there\"",
            "\"Wanna see me dance?\""
        });
        if (CanMoveUp()) {
            yield return MoveMeUp();
            yield return MoveMeDown();
        }
        if (CanMoveDown()) {
            yield return MoveMeDown();
            yield return MoveMeUp();
        }
        if (CanMoveLeft()) {
            yield return MoveMeLeft();
            yield return MoveMeRight();
        }
        if (CanMoveRight()) {
            yield return MoveMeRight();
            yield return MoveMeLeft();
        }
        yield return StartDialog(new List<string>{
            "\"You liked it?\""
        });
        HideDialogBackground();
        EnableMovingThis();
        EnablePlayerMovement();
    }
}
