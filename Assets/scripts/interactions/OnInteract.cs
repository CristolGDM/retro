using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class OnInteract : MonoBehaviour {

    public virtual IEnumerator StartInteraction() {
        GameData.PlayerCanMove = true;
        yield break;
    }
}
