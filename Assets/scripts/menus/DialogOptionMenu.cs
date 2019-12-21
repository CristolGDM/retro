using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogOptionMenu : MenuComponent {

    [SerializeField]
    GameObject YesOption;
    [SerializeField]
    GameObject NoOption;

    private MenuComponent CallingMenu;
    private bool hasSelected;
    private bool selectedOption;

    private bool canBeClosed = false;
    public override bool CanBeClosed() { return canBeClosed; }

    public new void Start() {
        base.Start();
    }

    protected override void LoadOptions() {
        List<List<GameObject>> tempList = new List<List<GameObject>> {
            new List<GameObject> { YesOption },
            new List<GameObject> { NoOption }
        };

        SelectableOptions = tempList;
        canBeClosed = false;
    }

    protected override void SelectOption(GameObject option) {
        selectedOption = option == YesOption;
        hasSelected = true;
    }

    public IEnumerator WaitForSelection(Action<bool> callback) {
        hasSelected = false;

        while (!hasSelected) {
            yield return null;
        }

        callback(selectedOption);
        canBeClosed = true;
        GameObject.Find(ComponentNames.SceneScripts).GetComponent<MenuManager>().CloseAllMenus();
        yield break;
    }
}
