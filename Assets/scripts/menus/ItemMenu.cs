using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MenuComponent {

    private readonly int maxRows = 4;
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

        sampleItem.GetComponent<Text>().text = "";
        sampleItem.SetActive(false);
        itemDescriptionField.GetComponent<Text>().text = "";
    }

    public new void Update() {
        base.Update();
        itemDescriptionField.GetComponent<Text>().text = Inventory.GetItem(CurrentOption().name).Description;
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
                float newItemX = xStart + ((count % maxRows)*optionWidth);
                float newItemY = yStart - (Options.Count * (optionHeight + 5));
                float newItemZ = sampleItem.transform.localPosition.z;
                newObject.transform.localPosition = new Vector3(newItemX, newItemY, newItemZ);
                newObject.transform.SetParent(sampleItem.transform.parent);
                newObject.transform.localScale = new Vector3(1, 1, 1);
                newObject.GetComponent<Text>().text = Inventory.GetItem(key).Name;
                newObject.name = key;
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
        Item selectedItem = Inventory.GetItem(option.name);

        if (selectedItem.IsUsable) {
            selectedItem.OnUse();
        }
    }
}
