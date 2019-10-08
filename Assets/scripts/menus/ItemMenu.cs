using System.Collections.Generic;
using UnityEngine;

public class ItemMenu : MenuComponent {

    private readonly int maxRows = 3;

    public new void Start() {
        base.Start();
    }

    protected override void LoadOptions() {
        List<List<GameObject>> Options = new List<List<GameObject>>();

        int count = 0;
        int dictCount = 0;
        List<GameObject> row = new List<GameObject>();

        foreach(string key in Inventory.CarriedInventory.Keys) {
            dictCount += 1;
            if(Inventory.CarriedInventory[key] > 0) {
                row.Add(new GameObject());
                count += 1;

                if (count == maxRows || dictCount == Inventory.CarriedInventory.Keys.Count) {
                    Options.Add(row);
                    row = new List<GameObject>();
                    count = 0;
                }
            }
        }

        SelectableOptions = Options;
        SelectOption(0, 0);
    }

    protected override void SelectOption(GameObject option) {
    }
}
