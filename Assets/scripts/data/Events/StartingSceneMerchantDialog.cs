﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        bool saidYes = false;
        yield return AskDialogOption((answer) => { saidYes = answer; });

        if (saidYes) {
            if (CanMoveUp()) {
                yield return MoveMeUp();
                yield return new WaitForSeconds(.1f);
                FaceRight();
                yield return new WaitForSeconds(.1f);
                FaceDown();
                yield return new WaitForSeconds(.1f);
                FaceLeft();
                yield return new WaitForSeconds(.1f);
                FaceUp();
                yield return new WaitForSeconds(.1f);
                yield return MoveMeDown();
            }
            if (CanMoveDown()) {
                yield return MoveMeDown();
                yield return new WaitForSeconds(.1f);
                FaceLeft();
                yield return new WaitForSeconds(.1f);
                FaceUp();
                yield return new WaitForSeconds(.1f);
                FaceRight();
                yield return new WaitForSeconds(.1f);
                FaceDown();
                yield return new WaitForSeconds(.1f);
                yield return MoveMeUp();
            }
            if (CanMoveLeft()) {
                yield return MoveMeLeft();
                yield return new WaitForSeconds(.1f);
                FaceUp();
                yield return new WaitForSeconds(.1f);
                FaceRight();
                yield return new WaitForSeconds(.1f);
                FaceDown();
                yield return new WaitForSeconds(.1f);
                FaceLeft();
                yield return new WaitForSeconds(.1f);
                yield return MoveMeRight();
            }
            if (CanMoveRight()) {
                yield return MoveMeRight();
                FaceDown();
                yield return new WaitForSeconds(.1f);
                FaceLeft();
                yield return new WaitForSeconds(.1f);
                FaceUp();
                yield return new WaitForSeconds(.1f);
                FaceRight();
                yield return new WaitForSeconds(.1f);
                yield return MoveMeLeft();
            }
            TurnTowardPlayer();
            yield return StartDialog(new List<string>{
                "\"You liked it?\""
            });
        }
        else {
            yield return StartDialog(new List<string>{
                "\"Too bad...\""
            });
        }
        
        HideDialogBackground();
        EnableMovingThis();
        EnablePlayerMovement();
    }
}
