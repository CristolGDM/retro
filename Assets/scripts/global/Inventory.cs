using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Inventory {

    private static Dictionary<string, Item> ItemDB = new Dictionary<string, Item>();
    private static Dictionary<string, int> CarriedInventory = new Dictionary<string, int>();

    private static readonly int maxItemStack = 99;

    private static int gold = 300;
    private static readonly int maxGold = 999999;

    public static void AddItemToInventory(string itemID, int amount) {
        int newAmount;
        string key = ParseKeyName(itemID);

        if (CarriedInventory.ContainsKey(key)) {
            newAmount = CarriedInventory[key] + amount;
        }
        else {
            newAmount = amount;
        }

        CarriedInventory[key] = Math.Min(newAmount, maxItemStack);
    }
    public static void AddItemToInventory(string itemID) {
        AddItemToInventory(itemID, 1);
    }
    public static void AddItemToInventory(Item item, int amount) {
        AddItemToInventory(item.Name, amount);
    }
    public static void AddItemToInventory(Item item) {
        AddItemToInventory(item, 1);
    }

    public static void RemoveItemFromInventory(string itemID, int amount) {
        int newAmount;
        string key = ParseKeyName(itemID);

        if (CarriedInventory.ContainsKey(key)) {
            newAmount = CarriedInventory[key] - amount;

            if (newAmount <= 0) {
                CarriedInventory.Remove(key);
            } else {
                CarriedInventory[key] = Math.Max(newAmount, 0);
            }
        }

    }
    public static void RemoveItemFromInventory(string itemID) {
        RemoveItemFromInventory(itemID, 1);
    }
    public static void RemoveItemFromInventory(Item item, int amount) {
        RemoveItemFromInventory(item.Name, amount);
    }
    public static void RemoveItemFromInventory(Item item) {
        RemoveItemFromInventory(item, 1);
    }

    public static Item GetItem(string itemID) {
        string key = ParseKeyName(itemID);
        if (!ItemDB.ContainsKey(key)) return null;
        return ItemDB[key];
    }

    public static void AddItemToDatabase(Item item) {
        string key = ParseKeyName(item.Name);
        ItemDB[key] = item;
    }

    private static string ParseKeyName (string unparsedKey) {
        unparsedKey = unparsedKey.ToLower();
        unparsedKey = Regex.Replace(unparsedKey, "[^a-zA-Z0-9_.]+", "");
        return unparsedKey;
    }

    public static int GetCarriedAmount (string itemID) {
        string key = ParseKeyName(itemID);

        if (!CarriedInventory.ContainsKey(key)) return 0;

        return CarriedInventory[key];
    }
    public static int GetCarriedAmount (Item item) {
        return GetCarriedAmount(item.Name);
    }

    public static List<string> GetCarriedItems() {
        return new List<string>(CarriedInventory.Keys);
    }

    public static int GetGold() {
        return gold;
    }

    public static bool CanSpend(int amount) {
        return gold >= amount;
    }

    public static void SpendGold(int amount) {
        gold = Math.Max(0, gold - amount);
    }

    public static void AddGold(int amount) {
        gold = Math.Min(maxGold, gold + amount);
    }
}
