using System.Collections;
using System.Collections.Generic;

public class StartingSceneMerchantDialog : EventTrigger {

    public override IEnumerator StartInteraction() {
        DisableMovingThis();
        DisablePlayerMovement();
        TurnTowardPlayer();
        ShowDialogBackground();
        yield return StartCoroutine(StartDialog(new List<string>{
            "\"Hello there\"",
            "\"Wanna see me dance?\""
        }));
        if (CanMoveUp()) {
            yield return StartCoroutine(MoveMeUp());
            yield return StartCoroutine(MoveMeDown());
        }
        if (CanMoveDown()) {
            yield return StartCoroutine(MoveMeDown());
            yield return StartCoroutine(MoveMeUp());
        }
        if (CanMoveLeft()) {
            yield return StartCoroutine(MoveMeLeft());
            yield return StartCoroutine(MoveMeRight());
        }
        if (CanMoveRight()) {
            yield return StartCoroutine(MoveMeRight());
            yield return StartCoroutine(MoveMeLeft());
        }
        yield return StartCoroutine(StartDialog(new List<string>{
            "\"You liked it?\""
        }));
        HideDialogBackground();
        EnableMovingThis();
        EnablePlayerMovement();
    }
}
