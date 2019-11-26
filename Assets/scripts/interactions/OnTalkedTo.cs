using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTalkedTo : EventTrigger {

    [SerializeField]
    private List<string> dialog = new List<string> { "..." };
    private CharacterMover mover;

    ///////////////////////////////////////

    public override IEnumerator StartInteraction() {
        yield return StartCoroutine(StartDialog());
    }

    private IEnumerator StartDialog() {
        DisableMovingThis();
        DisablePlayerMovement();
        TurnTowardPlayer();
        yield return StartCoroutine(StartDialog(dialog));
        EnableMovingThis();
        EnablePlayerMovement();
    }
}
