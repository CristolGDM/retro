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
    private readonly string inventoryMode;
    private readonly string shopBuyMode;
    private readonly string shopSellMode;
    private enum Modes { inventoryMode, shopBuyMode, shopSellMode };
    private Modes currentMode = Modes.inventoryMode;
	
	// Update is called once per frame
	void Update () {
        if(thisItem != null) {
            itemName.text = thisItem.Name;

            if (currentMode == Modes.shopBuyMode) {
                itemAmount.text = "" + thisItem.Cost;
            } else {
                itemAmount.text = "" + Inventory.GetCarriedAmount(thisItem);
            }
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

    public void LoadShopBuyItem(Item newItem) {
        currentMode = Modes.shopBuyMode;
        LoadItem(newItem);
    }

    public void LoadShopSellItem(Item newItem) {
        currentMode = Modes.shopSellMode;
        LoadItem(newItem);
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
