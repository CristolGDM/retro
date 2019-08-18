using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMover))]
public class RandomMovement : MonoBehaviour {
    private CharacterMover mover;

    // Use this for initialization
    void Start() {
        mover = GetComponent<CharacterMover>();
        float startMoving = Random.Range(0.5f, 3.5f);
        float moveInterval = Random.Range(3.0f, 8.0f);
        InvokeRepeating("MoveRandomDirection", startMoving, moveInterval);
    }

    // Update is called once per frame
    void MoveRandomDirection() {
        int whichDirection = Random.Range(0, 5);

        if(whichDirection < 1) {
            mover.MoveUp();
        } else if(whichDirection < 2) {
            mover.MoveDown();
        } else if (whichDirection < 3) {
            mover.MoveLeft();
        } else if (whichDirection < 4) {
            mover.MoveRight();
        } else {
            mover.StopMoving();
        }
    }
}
