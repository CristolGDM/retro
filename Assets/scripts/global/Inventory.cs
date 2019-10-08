using System;
using System.Collections.Generic;

public class Inventory {
    private static Dictionary<string, Item> ItemDB = new Dictionary<string, Item>() {
        { "00001", new Potion()},
        { "00002", new Poison()},
    };

    public static Dictionary<string, int> CarriedInventory = new Dictionary<string, int>();

    private static readonly int maxItemStack = 99;

    public static void AddItemToInventory(string itemID, int amount) {
        if (ItemDB.ContainsKey(itemID)) {
            int newAmount;

            if (CarriedInventory.ContainsKey(itemID)) {
                newAmount = CarriedInventory[itemID] + amount;
            }
            else {
                newAmount = amount;
            }

            CarriedInventory[itemID] = Math.Min(newAmount, maxItemStack);
        }
    }

    public static void RemoveItemFromInventory(string itemID, int amount) {
        if (ItemDB.ContainsKey(itemID)) {
            int newAmount;

            if (CarriedInventory.ContainsKey(itemID)) {
                newAmount = CarriedInventory[itemID] - amount;
            }
            else {
                newAmount = amount;
            }

            CarriedInventory[itemID] = Math.Max(newAmount, 0);
        }
    }

    public static Item GetItem(string itemId) {
        return ItemDB[itemId];
    }
}
