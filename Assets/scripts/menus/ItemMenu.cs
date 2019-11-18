using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MenuComponent {

    private readonly int maxColumns = 3;
    private readonly int maxRows = 7;
    private readonly int verticalMargin = 5;
    private readonly int horizMargin = 0;
    [SerializeField]
    private GameObject sampleItem;
    [SerializeField]
    private GameObject itemDescriptionField;
    [SerializeField]
    private GameObject itemTargetMenu;

    private float xStart;
    private float yStart;
    private float optionWidth;
    private float optionHeight;

    private List<GameObject> optionsAsLine = new List<GameObject>();

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

        List<string> currentItems = new List<string> ( Inventory.CarriedInventory.Keys );

        for (int i = 0; i < optionsAsLine.Count; i++) {
            if(i < currentItems.Count) {
                optionsAsLine[i].GetComponent<ItemComponent>().LoadItem(currentItems[i]);
            }
            else {
                optionsAsLine[i].GetComponent<ItemComponent>().LoadItem("");
            }
        }

        if (CurrentOption() != null) {
            itemDescriptionField.GetComponent<Text>().text = CurrentOption().GetComponent<ItemComponent>().GetDescription();
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
                GameObject newObject = Instantiate(sampleItem);
                // You would expect an instantiated item to have the same coordinates and parent as the object being instantiated, but nooooo
                newObject.transform.position = new Vector3(sampleItem.transform.position.x, sampleItem.transform.position.y, sampleItem.transform.position.z);
                float newItemX = xStart + (col * (optionWidth + horizMargin));
                float newItemY = yStart - (row * (optionHeight + verticalMargin));
                float newItemZ = sampleItem.transform.localPosition.z;
                newObject.transform.SetParent(sampleItem.transform.parent);
                newObject.transform.localScale = new Vector3(1, 1, 1);
                newObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(newItemX, newItemY);

                tempOptionsAsLine.Add(newObject);
                optionsRow.Add(newObject);
            }

            tempSelectableOptions.Add(optionsRow);
            MoveToOption(0, 0);
        }

        SelectableOptions = tempSelectableOptions;
        optionsAsLine = tempOptionsAsLine;

        sampleItem.SetActive(false);
    }

    protected override void SelectOption(GameObject option) {
        Item selectedItem = option.GetComponent<ItemComponent>().GetItem();

        if (selectedItem == null) return;

        if (Inventory.CarriedInventory[selectedItem.Name] <= 0) return;

        if (selectedItem.IsUsable) {
            itemTargetMenu.GetComponent<ItemTargetMenu>().ReadyItem(selectedItem);
            menuManager.OpenSpecificMenu(itemTargetMenu);
        }
    }
}
