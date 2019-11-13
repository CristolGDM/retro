using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemConfirmationMenu : MenuComponent {

    [SerializeField]
    GameObject YesOption;
    [SerializeField]
    GameObject NoOption;
    [SerializeField]
    GameObject ConfirmationText;

    private MenuComponent CallingMenu;
    private Action YesAction;
    private Action NoAction;
    private Item selectedItem;
    private PlayerCharacter selectedCharacter;

    public new void Start() {
        base.Start();
    }

    protected override void LoadOptions() {
        List<List<GameObject>> tempList = new List<List<GameObject>>();

        tempList.Add(new List<GameObject> { YesOption });
        tempList.Add(new List<GameObject> { NoOption });

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

    public void Init(Item item, PlayerCharacter pc) {
        selectedItem = item;
        selectedCharacter = pc;

        ConfirmationText.GetComponent<Text>().text = "Do you want to use " + selectedItem.Name + " on " + selectedCharacter.characterName + "?";
    }

    public void LoadYesNoActions(Action yesAction, Action noAction) {
        YesAction = yesAction;
        NoAction = noAction;
    }
}
