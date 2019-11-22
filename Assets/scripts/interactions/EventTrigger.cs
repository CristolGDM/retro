using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventTrigger : OnInteract {

    public void Start() {
    }

    public void Update() {
    }

    ///////////////////////////////////////

    public override void StartInteraction() {
    }

    protected void DisableMoving() {
        CharacterMover mover = gameObject.GetComponent<CharacterMover>();
        mover.CanMove = false;
    }

    protected void EnableMoving() {
        CharacterMover mover = gameObject.GetComponent<CharacterMover>();
        mover.CanMove = true;
    }

    protected void StartDialog(List<string> dialog) {
        GameObject.Find(ComponentNames.SceneScripts).GetComponent<DialogHandler>().StartNewDialog(dialog);
    }

    protected void TurnTowardPlayer() {
        int playerDirection = GameObject.Find(ComponentNames.PlayerCharacter).GetComponent<Animator>().GetInteger("Direction");
        CharacterMover mover = gameObject.GetComponent<CharacterMover>();
        mover.animator.SetInteger("Direction", (playerDirection + 2) % 4);
    }
}
