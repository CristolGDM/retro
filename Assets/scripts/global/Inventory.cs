using System;
using System.Collections.Generic;

public class Inventory {

    public static Dictionary<string, Item> ItemDB = new Dictionary<string, Item>();
    public static Dictionary<string, int> CarriedInventory = new Dictionary<string, int>();

    private static readonly int maxItemStack = 99;

    public static void AddItemToInventory(Item item, int amount) {
        int newAmount;
        string itemID = item.Name;

        ItemDB[itemID] = item;

        if (CarriedInventory.ContainsKey(itemID)) {
            newAmount = CarriedInventory[itemID] + amount;
        }
        else {
            newAmount = amount;
        }

        CarriedInventory[itemID] = Math.Min(newAmount, maxItemStack);
    }

    public static void RemoveItemFromInventory(Item item, int amount) {
        int newAmount;
        string itemID = item.Name;

        ItemDB[itemID] = item;

        if (CarriedInventory.ContainsKey(itemID)) {
            newAmount = CarriedInventory[itemID] - amount;

            if (newAmount <= 0) {
                CarriedInventory.Remove(itemID);
            } else {
                CarriedInventory[itemID] = Math.Max(newAmount, 0);
            }
        }

    }

    public static Item GetItem(string itemId) {
        return ItemDB[itemId];
    }
}
