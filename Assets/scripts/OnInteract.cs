using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class OnInteract : MonoBehaviour {

    protected GameObject dialogBoxText;
    protected GameObject dialogBoxBackground;

    private void Start() {
        dialogBoxText = GameObject.Find(ComponentNames.DialogBoxText);
        dialogBoxBackground = GameObject.Find(ComponentNames.DialogBoxBackground);
    }
    public virtual void StartInteraction() {
        GameData.PlayerCanMove = true;
    }
}
