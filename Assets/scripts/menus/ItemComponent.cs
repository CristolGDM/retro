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
        if (!Inventory.CarriedInventory.ContainsKey(thisItem.Name) || Inventory.CarriedInventory[thisItem.Name] <= 0) {
            gameObject.SetActive(false);
            thisItem = null;
        } else {
            itemName.text = thisItem.Name;
            itemAmount.text = "" + Inventory.CarriedInventory[thisItem.Name];
        }
	}

    public void LoadItem (Item newItem) {
        thisItem = newItem;
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
