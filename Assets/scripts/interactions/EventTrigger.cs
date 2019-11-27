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

    /*
     * MOVING TRIGGERS
     */

    protected IEnumerator MoveCharacterUp(CharacterMover mover) {
        yield return mover.MoveUp();
        yield break;
    }
    protected IEnumerator MoveCharacterUp(GameObject movingObject) {
        CharacterMover mover = movingObject.GetComponent<CharacterMover>();
        if (mover != null) {
            yield return StartCoroutine(MoveCharacterUp(mover));
        }
        else {
            yield break;
        }
    }
    protected IEnumerator MoveMeUp() {
        yield return StartCoroutine(MoveCharacterUp(gameObject));
    }

    ///

    protected IEnumerator MoveCharacterRight(CharacterMover mover) {
        yield return mover.MoveRight();
        yield break;
    }
    protected IEnumerator MoveCharacterRight(GameObject movingObject) {
        CharacterMover mover = movingObject.GetComponent<CharacterMover>();
        if (mover != null) {
            yield return StartCoroutine(MoveCharacterRight(mover));
        }
        else {
            yield break;
        }
    }
    protected IEnumerator MoveCharacterRight() {
        yield return StartCoroutine(MoveCharacterRight(gameObject));
    }
    protected IEnumerator MoveMeRight() {
        yield return StartCoroutine(MoveCharacterRight(gameObject));
    }

    ///

    protected IEnumerator MoveCharacterDown(CharacterMover mover) {
        yield return mover.MoveDown();
        yield break;
    }
    protected IEnumerator MoveCharacterDown(GameObject movingObject) {
        CharacterMover mover = movingObject.GetComponent<CharacterMover>();
        if (mover != null) {
            yield return StartCoroutine(MoveCharacterDown(mover));
        }
        else {
            yield break;
        }
    }
    protected IEnumerator MoveCharacterDown() {
        yield return StartCoroutine(MoveCharacterDown(gameObject));
    }
    protected IEnumerator MoveMeDown() {
        yield return StartCoroutine(MoveCharacterDown(gameObject));
    }

    ///

    protected IEnumerator MoveCharacterLeft(CharacterMover mover) {
        yield return mover.MoveLeft();
        yield break;
    }
    protected IEnumerator MoveCharacterLeft(GameObject movingObject) {
        CharacterMover mover = movingObject.GetComponent<CharacterMover>();
        if (mover != null) {
            yield return StartCoroutine(MoveCharacterLeft(mover));
        }
        else {
            yield break;
        }
    }
    protected IEnumerator MoveCharacterLeft() {
        yield return StartCoroutine(MoveCharacterLeft(gameObject));
    }
    protected IEnumerator MoveMeLeft() {
        yield return StartCoroutine(MoveCharacterLeft(gameObject));
    }

    /*
     * FACING TRIGGERS
     */

    protected void TurnTowardPlayer() {
        int playerDirection = GameObject.Find(ComponentNames.PlayerCharacter).GetComponent<Animator>().GetInteger("Direction");
        CharacterMover mover = gameObject.GetComponent<CharacterMover>();
        mover.animator.SetInteger("Direction", (playerDirection + 2) % 4);
    }

    ///

    protected void FaceUp(CharacterMover mover) {
        mover.animator.SetInteger("Direction", 2);
    }
    protected void FaceUp(GameObject facingObject) {
        CharacterMover mover = facingObject.GetComponent<CharacterMover>();
        if (mover != null) FaceUp(mover);
    }
    protected void FaceUp() {
        FaceUp(gameObject);
    }

    ///

    protected void FaceRight(CharacterMover mover) {
        mover.animator.SetInteger("Direction", 3);
    }
    protected void FaceRight(GameObject facingObject) {
        CharacterMover mover = facingObject.GetComponent<CharacterMover>();
        if (mover != null) FaceRight(mover);
    }
    protected void FaceRight() {
        FaceRight(gameObject);
    }

    ///

    protected void FaceDown(CharacterMover mover) {
        mover.animator.SetInteger("Direction", 0);
    }
    protected void FaceDown(GameObject facingObject) {
        CharacterMover mover = facingObject.GetComponent<CharacterMover>();
        if (mover != null) FaceDown(mover);
    }
    protected void FaceDown() {
        FaceDown(gameObject);
    }

    ///

    protected void FaceLeft(CharacterMover mover) {
        mover.animator.SetInteger("Direction", 1);
    }
    protected void FaceLeft(GameObject facingObject) {
        CharacterMover mover = facingObject.GetComponent<CharacterMover>();
        if (mover != null) FaceLeft(mover);
    }
    protected void FaceLeft() {
        FaceLeft(gameObject);
    }
}
