using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInteract : MonoBehaviour {
    public string myName = "noname";

	public void StartInteraction() {
        Debug.Log("Hey there I'm " + myName);
        GameData.PlayerCanMove = true;
    }
}
