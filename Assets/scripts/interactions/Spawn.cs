using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public bool clearTransit = false;

    private void OnTriggerExit2D(Collider2D other) {
        if (clearTransit) {
            clearTransit = false;
            GameData.PlayerCanTransition = true;
        }
    }
}
