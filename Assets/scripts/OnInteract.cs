using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class OnInteract : MonoBehaviour {

    protected GameObject dialogText;
    protected GameObject dialogBox;

    private void Start() {
        dialogText = GameObject.Find(ComponentNames.DialogText);
        dialogBox = GameObject.Find(ComponentNames.DialogBox);
    }
    public virtual void StartInteraction() {
        GameData.PlayerCanMove = true;
    }
}
