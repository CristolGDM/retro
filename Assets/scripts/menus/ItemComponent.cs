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
        itemName.text = thisItem.Name;
        itemAmount.text = "" + Inventory.CarriedInventory[thisItem.Name];
	}

    public void LoadItem (Item newItem) {
        thisItem = newItem;
    }

    public Item GetItem() {
        return thisItem;
    }
}
