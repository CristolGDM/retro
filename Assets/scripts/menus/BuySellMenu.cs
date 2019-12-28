using System.Collections.Generic;
using UnityEngine;

public class BuySellMenu : MenuComponent {

    [SerializeField]
    GameObject BuyOption;
    [SerializeField]
    GameObject SellOption;

    [SerializeField]
    GameObject ItemMenu;

    public new void Start() {
        base.Start();
    }

    protected override void LoadOptions() {
        List<List<GameObject>> Options = new List<List<GameObject>> {
            new List<GameObject> { BuyOption },
            new List<GameObject> { SellOption }
        };

        SelectableOptions = Options;
        MoveToOption(0, 0);
    }

    protected override void SelectOption(GameObject option) {
        if(option == BuyOption) {
            Debug.Log("Trying to open buy menu");
        }
        else if(option == SellOption) {
            Debug.Log("Trying to open Sell menu");
        }
    }
}
