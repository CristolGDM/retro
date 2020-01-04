using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationMenu : MenuComponent {

    [SerializeField]
    private GameObject YesOption = null;
    [SerializeField]
    private GameObject NoOption = null;
    [SerializeField]
    private GameObject ConfirmationText = null;

    private Action YesAction;

    private string defaultConfirmText = "";
    private Action defaultCallback = () => { };

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
        menuManager.GoBack();
    }

    public void SetConfirmationText(string confirmText) {
        ConfirmationText.GetComponent<Text>().text = confirmText;
    }

    public void SetActionToConfirm(Action callback) {
        YesAction = callback;
    }

    public override void CloseMenu() {
        ConfirmationText.GetComponent<Text>().text = defaultConfirmText;
        YesAction = defaultCallback;
        base.CloseMenu();
    }
}
