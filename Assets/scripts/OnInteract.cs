using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class OnInteract : MonoBehaviour {

    public Text dialogBoxText;
    public Image dialogBoxBackground;

    private void Start() {
        dialogBoxText = GameObject.Find(ComponentNames.DialogBoxName).GetComponentInChildren<Text>();
        dialogBoxBackground = GameObject.Find(ComponentNames.DialogBoxName).GetComponentInChildren<Image>();
    }
    public virtual void StartInteraction() {
        GameData.PlayerCanMove = true;
    }
}
