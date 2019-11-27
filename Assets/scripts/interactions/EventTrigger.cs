using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventTrigger : OnInteract {

    private int dialogTransitionSpeed = 10;
    private Vector2 hideDialogMaskPosition = new Vector2(0, 3f);
    private Vector2 showDialogMaskPosition = new Vector2(0, -0.5f);

    ///////////////////////////////////////

    protected void DisableMovingThis() {
        CharacterMover mover = gameObject.GetComponent<CharacterMover>();
        mover.CanMove = false;
    }

    protected void DisablePlayerMovement() {
        GameData.PlayerCanMove = false;
    }

    protected void EnableMovingThis() {
        CharacterMover mover = gameObject.GetComponent<CharacterMover>();
        mover.CanMove = true;
    }

    protected void EnablePlayerMovement() {
        GameData.PlayerCanMove = true;
    }

    protected void HideDialogBackground() {
        GameObject dialogMask = GameObject.Find(ComponentNames.SceneScripts).GetComponent<DialogHandler>().dialogMask;
        dialogMask.GetComponent<UIMover>().MoveToNewPosition(hideDialogMaskPosition, dialogTransitionSpeed);
    }

    protected void ShowDialogBackground() {
        GameObject dialogMask = GameObject.Find(ComponentNames.SceneScripts).GetComponent<DialogHandler>().dialogMask;
        dialogMask.GetComponent<UIMover>().MoveToNewPosition(showDialogMaskPosition, dialogTransitionSpeed);
    }

    protected IEnumerator StartDialog(string dialogString) {
        yield return StartDialog(new List<string> { dialogString });
    }

    protected IEnumerator StartDialog(List<string> dialog) {
        DialogHandler dialogHandler = GameObject.Find(ComponentNames.SceneScripts).GetComponent<DialogHandler>();
        yield return StartCoroutine(dialogHandler.StartNewDialog(dialog));
    }

    protected void TurnTowardPlayer() {
        int playerDirection = GameObject.Find(ComponentNames.PlayerCharacter).GetComponent<Animator>().GetInteger("Direction");
        CharacterMover mover = gameObject.GetComponent<CharacterMover>();
        mover.animator.SetInteger("Direction", (playerDirection + 2) % 4);
    }
}
