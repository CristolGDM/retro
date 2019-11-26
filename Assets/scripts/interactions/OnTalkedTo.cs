using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTalkedTo : OnInteract {

    [SerializeField]
    private List<string> dialog = new List<string> { "..." };
    private CharacterMover mover;

    private void Start() {
        mover = gameObject.GetComponent<CharacterMover>();
    }

    private void Update() {
        if (!GameData.DialogIsOpen && !mover.CanMove) {
            mover.CanMove = true;
        }
    }

    ///////////////////////////////////////

    public override void StartInteraction() {
        StartCoroutine(StartDialog());
    }

    private IEnumerator StartDialog() {
        mover = gameObject.GetComponent<CharacterMover>();
        int playerDirection = GameObject.Find(ComponentNames.PlayerCharacter).GetComponent<Animator>().GetInteger("Direction");
        mover.animator.SetInteger("Direction", (playerDirection +2)%4 );
        if(mover != null) {
            mover.CanMove = false;
        }
        yield return GameObject.Find(ComponentNames.SceneScripts).GetComponent<DialogHandler>().StartNewDialog(dialog);
        yield break;
    }
}
