using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemsBuy : MenuComponent {

    private readonly int maxColumns = 2;
    private readonly int maxRows = 7;
    private readonly int verticalMargin = 5;
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
    private List<Item> shopItems = new List<Item>();

    public new void Start() {
        base.Start();

        itemDescriptionField.GetComponent<Text>().text = "";
        List<Text> sampleItemTexts = new List<Text>(sampleItem.GetComponentsInChildren<Text>());
        foreach (Text txt in sampleItemTexts) {
            txt.text = "";
        }
    }

    public new void Update() {
        base.Update();

        for (int i = 0; i < optionsAsLine.Count; i++) {
            ItemComponent itemComponent = optionsAsLine[i].GetComponent<ItemComponent>();
            if (i < shopItems.Count) {
                itemComponent.LoadShopBuyItem(shopItems[i]);
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

    public void LoadItems(List<Item> items) {
        shopItems = items;
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
                GameObject newObject = Instantiate(sampleItem);
                // You would expect an instantiated item to have the same coordinates and parent as the object being instantiated, but nooooo
                newObject.transform.position = new Vector3(sampleItem.transform.position.x, sampleItem.transform.position.y, sampleItem.transform.position.z);
                float newItemX = xStart + (col * (optionWidth + horizMargin));
                float newItemY = yStart - (row * (optionHeight + verticalMargin));
                newObject.transform.SetParent(sampleItem.transform.parent);
                newObject.transform.localScale = new Vector3(1, 1, 1);
                newObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(newItemX, newItemY);

                tempOptionsAsLine.Add(newObject);
                optionsRow.Add(newObject);
                if (tempOptionsAsLine.Count == shopItems.Count) break;
            }

            tempSelectableOptions.Add(optionsRow);
            if (tempOptionsAsLine.Count == shopItems.Count) break;
        }
        MoveToOption(0, 0);

        SelectableOptions = tempSelectableOptions;
        optionsAsLine = tempOptionsAsLine;

        sampleItem.SetActive(false);
    }

    protected override void SelectOption(GameObject option) {
        Item selectedItem = option.GetComponent<ItemComponent>().GetItem();

        if (selectedItem == null) return;

        if(Inventory.CanSpend(selectedItem.Cost)) {
            Inventory.SpendGold(selectedItem.Cost);
            Inventory.AddItemToInventory(selectedItem, 1);
        }
    }

    public override void PlaceCursorOnOption(GameObject option) {
        RectTransform rectTrans = option.GetComponent<RectTransform>();
        float cursorLeftOffset = ((1.2f * rectTrans.rect.width) / 120) + 0.1f;
        Cursor.transform.position = new Vector3(CurrentOption().transform.position.x - cursorLeftOffset, CurrentOption().transform.position.y - 0.1f, CurrentOption().transform.position.z);
    }
}
