using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnInteract : MonoBehaviour {

	public virtual void StartInteraction() {
        GameData.PlayerCanMove = true;
    }
}
