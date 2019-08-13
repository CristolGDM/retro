using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMover))]
public class RandomMovement : MonoBehaviour {
    private CharacterMover mover;

    // Use this for initialization
    void Start() {
        mover = GetComponent<CharacterMover>();
        //float startMoving = Random.Range(1.5f, 2.5f);
        //float moveInterval = Random.Range()
        InvokeRepeating("MoveRandomDirection", 1.0f, 2.0f);
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
