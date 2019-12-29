using System.Collections.Generic;
using UnityEngine;

public class BuySellMenu : MenuComponent {

    [SerializeField]
    private GameObject BuyOption = null;
    [SerializeField]
    private GameObject SellOption = null;
    [SerializeField]
    private GameObject ShopItemsMenu = null;

    private List<Item> shopItems;

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
            ShopItemsMenu.GetComponent<ShopItemsBuy>().LoadItems(shopItems);
            menuManager.OpenSpecificMenu(ShopItemsMenu);
        }
        else if(option == SellOption) {
            Debug.Log("Trying to open Sell menu");
        }
    }

    public void LoadItems(List<Item> items) {
        shopItems = items;
    }
}
