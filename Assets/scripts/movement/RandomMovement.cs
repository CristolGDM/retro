using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMover))]
public class RandomMovement : MonoBehaviour {
    private CharacterMover mover;

    // Use this for initialization
    void Start() {
        mover = GetComponent<CharacterMover>();
        float startMoving = Random.Range(0.5f, 1.5f);
        float moveInterval = Random.Range(3.0f, 5.0f);
        InvokeRepeating("MoveRandomDirection", startMoving, moveInterval);
    }

    // Update is called once per frame
    void MoveRandomDirection() {
        if (!mover.CanMove) return;
        int whichDirection = Random.Range(0, 5);

        if(whichDirection < 1) {
            StartCoroutine(mover.MoveUp());
        } else if(whichDirection < 2) {
            StartCoroutine(mover.MoveDown());
        } else if (whichDirection < 3) {
            StartCoroutine(mover.MoveLeft());
        } else if (whichDirection < 4) {
            StartCoroutine(mover.MoveRight());
        } else {
            mover.StopMoving();
        }
    }
}
