using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTalkedTo : EventTrigger {

    [SerializeField]
    private List<string> dialog = new List<string> ();
    private CharacterMover mover;

    ///////////////////////////////////////

    public override IEnumerator StartInteraction() {
        yield return StartCoroutine(StartDialog());
    }

    private IEnumerator StartDialog() {
        if (dialog.Count == 0 || dialog[0].Length == 0) yield break;
        DisableMovingThis();
        DisablePlayerMovement();
        TurnTowardPlayer();
        ShowDialogBackground();
        yield return StartDialog(dialog);
        HideDialogBackground();
        EnableMovingThis();
        EnablePlayerMovement();
    }
}
