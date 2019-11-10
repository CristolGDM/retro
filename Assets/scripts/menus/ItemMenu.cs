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

    private float xStart;
    private float yStart;
    private float optionWidth;
    private float optionHeight;

    private List<GameObject> optionsAsLine = new List<GameObject>();

    public new void Start() {
        base.Start();

        itemDescriptionField.GetComponent<Text>().text = "";

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

        xStart = sampleItem.transform.localPosition.x;
        yStart = sampleItem.transform.localPosition.y;
        RectTransform rt = sampleItem.GetComponent<RectTransform>();
        optionWidth = rt.rect.width;
        optionHeight = rt.rect.height;

        for (int row = 0; row < maxRows; row++) {

            List<GameObject> optionsRow = new List<GameObject>();

            for (int col = 0; col < maxColumns; col++) {
                GameObject newObject = Instantiate(sampleItem);
                float newItemX = xStart + (col * (optionWidth + horizMargin));
                float newItemY = yStart - (row * (optionHeight + verticalMargin));
                float newItemZ = sampleItem.transform.localPosition.z;
                newObject.transform.localPosition = new Vector3(newItemX, newItemY, newItemZ);
                newObject.transform.SetParent(sampleItem.transform.parent);
                newObject.transform.localScale = new Vector3(1, 1, 1);

                optionsAsLine.Add(newObject);
                optionsRow.Add(newObject);
            }

            SelectableOptions.Add(optionsRow);
            SelectOption(0, 0);
        }

        sampleItem.SetActive(false);
    }

    protected override void SelectOption(GameObject option) {
        Item selectedItem = option.GetComponent<ItemComponent>().GetItem();

        if (selectedItem == null) return;

        if (Inventory.CarriedInventory[selectedItem.Name] <= 0) return;

        if (selectedItem.IsUsable) {
            if (selectedItem.NeedTarget) {
                List<PlayerCharacter> targets = new List<PlayerCharacter>();
                targets.Add(GameData.getFirstPc());
                selectedItem.SetTargets(targets.ToArray());
            } else {
                selectedItem.SetTargets(GameData.getParty());
            }
            selectedItem.OnUse();
        }
    }
}
