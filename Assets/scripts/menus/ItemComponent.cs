using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemComponent : MonoBehaviour {

    [SerializeField]
    Text itemName;

    [SerializeField]
    Text itemAmount;

    private Item thisItem;
	
	// Update is called once per frame
	void Update () {
        if(thisItem != null && Inventory.CarriedInventory.ContainsKey(thisItem.Name) && Inventory.CarriedInventory[thisItem.Name] > 0) {
            itemName.text = thisItem.Name;
            itemAmount.text = "" + Inventory.CarriedInventory[thisItem.Name];
        }
        else {
            itemName.text = "";
            itemAmount.text = "";
            thisItem = null;
        } 
	}

    public void LoadItem (Item newItem) {
        thisItem = newItem;
    }

    public void LoadItem (string itemId) {
        LoadItem(Inventory.GetItem(itemId));
    }

    public Item GetItem() {
        return thisItem;
    }

    public string GetDescription() {
        if (thisItem == null) {
            return "";
        }
        return thisItem.Description;
    }
}
