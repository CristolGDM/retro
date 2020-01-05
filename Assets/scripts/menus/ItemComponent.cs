using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemComponent : MonoBehaviour {

    [SerializeField]
    private Text itemName = null;

    [SerializeField]
    private Text itemAmount = null;

    private Item thisItem;
    private readonly string inventoryMode;
    private readonly string shopBuyMode;
    private readonly string shopSellMode;
    private enum Modes { inventoryMode, shopBuyMode, shopSellMode };
    private Modes currentMode = Modes.inventoryMode;
	
	// Update is called once per frame
	void Update () {
        bool showOnlyCarriedItems = currentMode == Modes.inventoryMode || currentMode == Modes.shopSellMode;
        if(thisItem == null || (showOnlyCarriedItems && Inventory.GetCarriedAmount(thisItem) < 1)) {
            itemName.text = "";
            itemAmount.text = "";
            thisItem = null;
        }
        else {
            itemName.text = thisItem.Name;

            if (currentMode == Modes.shopBuyMode) {
                itemAmount.text = "" + thisItem.Cost;
            } else if (currentMode == Modes.shopSellMode) {
                itemAmount.text = "" + thisItem.CostSell;
                if (Inventory.GetCarriedAmount(thisItem) > 1) {
                    itemName.text += " x" + Inventory.GetCarriedAmount(thisItem);
                }
            } else {
                itemAmount.text = "" + Inventory.GetCarriedAmount(thisItem);
            }
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
    public void LoadShopSellItem(string itemName) {
        LoadShopSellItem(Inventory.GetItem(itemName));
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
