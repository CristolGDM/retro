using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemConfirmationMenu : MenuComponent {

    [SerializeField]
    private GameObject YesOption = null;
    [SerializeField]
    private GameObject NoOption = null;
    [SerializeField]
    private GameObject ConfirmationText = null;

    private MenuComponent CallingMenu;
    private Action YesAction;
    private Action NoAction;

    public new void Start() {
        base.Start();
    }

    protected override void LoadOptions() {
        List<List<GameObject>> tempList = new List<List<GameObject>> {
            new List<GameObject> { YesOption },
            new List<GameObject> { NoOption }
        };

        SelectableOptions = tempList;
    }

    protected override void SelectOption(GameObject option) {
        if(option == YesOption) {
            YesAction();
        }
        else {
            NoAction();
        }
    }

    public void Init(Item item, PlayerCharacter[] targets) {

        string confirmText;

        if(targets.Length == 1) {
           confirmText  = "Do you want to use " + item.Name + " on " + targets[0].characterName + "?";
        }
        else {
            confirmText = "Do you want to use " + item.Name + " on everybody?";
        }

        ConfirmationText.GetComponent<Text>().text = confirmText;
    }

    public void LoadYesNoActions(Action yesAction, Action noAction) {
        YesAction = yesAction;
        NoAction = noAction;
    }
}
