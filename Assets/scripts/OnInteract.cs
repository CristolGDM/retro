using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInteract : MonoBehaviour {
    public string name = "noname";

	public void StartInteraction() {
        Debug.Log("Hey there I'm " + name);
    }
}
