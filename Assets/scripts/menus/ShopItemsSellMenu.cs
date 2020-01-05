using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemsSellMenu : MenuComponent {

    private readonly int maxColumns = 2;
    private readonly int maxRows = 5;
    private readonly int verticalMargin = -5;
    private readonly int horizMargin = 0;
    [SerializeField]
    private GameObject sampleItem = null;
    [SerializeField]
    private GameObject itemDescriptionField = null;

    private float xStart;
    private float yStart;
    private float optionWidth;
    private float optionHeight;

    private List<GameObject> optionsAsLine = new List<GameObject>();
    private List<Item> sellableItems = new List<Item>();

    public new void Start() {
        base.Start();

        itemDescriptionField.GetComponent<Text>().text = "";
        List<Text> sampleItemTexts = new List<Text>(sampleItem.GetComponentsInChildren<Text>());
        foreach (Text txt in sampleItemTexts) {
            txt.text = "";
        }
        foreach (string itemName in Inventory.GetCarriedItems()) {
            Item thisItem = Inventory.GetItem(itemName);

            if(thisItem != null && thisItem.CostSell > 0 && Inventory.GetCarriedAmount(thisItem) > 0) {
                sellableItems.Add(thisItem);
            }
        }
    }

    public new void Update() {
        base.Update();

        for (int i = 0; i < optionsAsLine.Count; i++) {
            ItemComponent itemComponent = optionsAsLine[i].GetComponent<ItemComponent>();
            if (i < sellableItems.Count) {
                itemComponent.LoadShopSellItem(sellableItems[i]);
            }
            else {
                itemComponent.LoadItem("");
            }
        }

        if (CurrentOption() != null) {
            itemDescriptionField.GetComponent<Text>().text = CurrentOption().GetComponent<ItemComponent>().GetDescription();
        }
    }

    public override void CloseMenu() {
        foreach (GameObject option in optionsAsLine) {
            Destroy(option);
        }
    }

    protected override void LoadOptions() {
        sampleItem.SetActive(true);

        RectTransform rt = sampleItem.GetComponent<RectTransform>();
        optionWidth = rt.rect.width;
        optionHeight = rt.rect.height;
        xStart = rt.anchoredPosition.x;
        yStart = rt.anchoredPosition.y;

        List<List<GameObject>> tempSelectableOptions = new List<List<GameObject>>();
        List<GameObject> tempOptionsAsLine = new List<GameObject>();

        for (int row = 0; row < maxRows; row++) {

            List<GameObject> optionsRow = new List<GameObject>();

            for (int col = 0; col < maxColumns; col++) {
                GameObject newObject = Instantiate(sampleItem, sampleItem.transform.parent);
                float newItemX = xStart + (col * (optionWidth + horizMargin));
                float newItemY = yStart - (row * (optionHeight + verticalMargin));
                newObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(newItemX, newItemY);

                tempOptionsAsLine.Add(newObject);
                optionsRow.Add(newObject);
            }

            tempSelectableOptions.Add(optionsRow);
        }
        MoveToOption(0, 0);

        SelectableOptions = tempSelectableOptions;
        optionsAsLine = tempOptionsAsLine;

        sampleItem.SetActive(false);
    }

    protected override void SelectOption(GameObject option) {
        Item selectedItem = option.GetComponent<ItemComponent>().GetItem();

        if (selectedItem == null) return;
        if (Inventory.GetCarriedAmount(selectedItem) < 1) return;
        if (selectedItem.CostSell <= 0) return;

        string confirmText = "How many \"" + selectedItem.Name + "\" do you want to sell?";
        int maxValue = Inventory.GetCarriedAmount(selectedItem);
        Action<int> callback = (int amount) => {
            string amountText = amount > 1 ? " x" + amount : "";
            string confirmAmountText = "Do you really want to sell " + selectedItem.Name + amountText + " for " + selectedItem.CostSell * amount + " gold?";
            Action confirmCallback = () => {
                Inventory.AddGold(selectedItem.CostSell * amount);
                Inventory.RemoveItemFromInventory(selectedItem, amount);
                menuManager.GoBack();
            };
            menuManager.OpenConfirmationMenu(confirmCallback, confirmAmountText);
        };

        menuManager.OpenAmountSelectMenu(confirmText, maxValue, callback);
    }
}
