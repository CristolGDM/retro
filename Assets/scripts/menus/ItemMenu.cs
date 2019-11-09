using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MenuComponent {

    private readonly int maxRows = 3;
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

    public new void Start() {
        base.Start();

        sampleItem.SetActive(false);
        itemDescriptionField.GetComponent<Text>().text = "";
    }

    public new void Update() {
        base.Update();
        if (CurrentOption() != null) {
            itemDescriptionField.GetComponent<Text>().text = CurrentOption().GetComponent<ItemComponent>().GetDescription();
        }
    }

    protected override void LoadOptions() {

        xStart = sampleItem.transform.localPosition.x;
        yStart = sampleItem.transform.localPosition.y;
        RectTransform rt = sampleItem.GetComponent<RectTransform>();
        optionWidth = rt.rect.width;
        optionHeight = rt.rect.height;

        List<List<GameObject>> Options = new List<List<GameObject>>();

        int count = 0;
        int dictCount = 0;
        List<GameObject> row = new List<GameObject>();

        sampleItem.SetActive(true);
        foreach(string key in Inventory.CarriedInventory.Keys) {
            dictCount += 1;
            if(Inventory.CarriedInventory[key] > 0) {
                GameObject newObject = Instantiate(sampleItem);
                float newItemX = xStart + ((count % maxRows)*(optionWidth + horizMargin));
                float newItemY = yStart - (Options.Count * (optionHeight + verticalMargin));
                float newItemZ = sampleItem.transform.localPosition.z;
                newObject.transform.localPosition = new Vector3(newItemX, newItemY, newItemZ);
                newObject.transform.SetParent(sampleItem.transform.parent);
                newObject.transform.localScale = new Vector3(1, 1, 1);

                newObject.GetComponent<ItemComponent>().LoadItem(Inventory.GetItem(key));

                row.Add(newObject);
                count += 1;

                if (count == maxRows || dictCount == Inventory.CarriedInventory.Keys.Count) {
                    Options.Add(row);
                    row = new List<GameObject>();
                    count = 0;
                }
            }
        }
        sampleItem.SetActive(false);

        SelectableOptions = Options;
        SelectOption(0, 0);
    }

    protected override void SelectOption(GameObject option) {
        Item selectedItem = option.GetComponent<ItemComponent>().GetItem();

        if (Inventory.CarriedInventory[selectedItem.Name] <= 0) return;

        if (selectedItem.IsUsable) {
            if (selectedItem.NeedTarget) {
                List<PlayerCharacter> targets = new List<PlayerCharacter>();
                targets.Add(GameData.getFirstPc());
                selectedItem.SetTargets(targets.ToArray());
            }
            else {
                selectedItem.SetTargets(GameData.getParty());
            }
            selectedItem.OnUse();

            LoadOptions();
        }
    }
}
