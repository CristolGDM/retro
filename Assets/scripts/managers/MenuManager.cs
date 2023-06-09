﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject mainMenu = null;
    [SerializeField]
    private GameObject dialogOption = null;
    [SerializeField]
    private GameObject shopMenu = null;
    [SerializeField]
    private GameObject confirmationMenu = null;
    [SerializeField]
    private GameObject amountSelectMenu = null;
    public GameObject DialogOption { get { return dialogOption; } }

    public GameObject Cursor;

    private List<GameObject> MenuStack = new List<GameObject>();

    public void Start() {
        CloseAllMenus();
    }

    public void OpenMenu() {
        OpenSpecificMenu(mainMenu);
    }

    public void OpenSpecificMenu(GameObject menuObject) {
        GameData.MenuIsOpen = true;
        MenuStack.Add(menuObject);
        menuObject.GetComponent<MenuComponent>().InitMenu();

        List<TilemapRenderer> allBackgrounds = new List<TilemapRenderer>(menuObject.GetComponentsInChildren<TilemapRenderer>());
        List<Canvas> allTexts = new List<Canvas>(menuObject.GetComponentsInChildren<Canvas>());
        List<SpriteRenderer> allSprites = new List<SpriteRenderer>(menuObject.GetComponentsInChildren<SpriteRenderer>());
        int baseOrder = MenuStack.Count*2 -1;
        foreach(TilemapRenderer bg in allBackgrounds) {
            bg.sortingOrder = baseOrder;
        }
        foreach (Canvas text in allTexts) {
            text.sortingOrder = baseOrder + 1;
        }
        foreach (SpriteRenderer sprite in allSprites) {
            sprite.sortingOrder = baseOrder + 1;
        }
        Cursor.GetComponent<SpriteRenderer>().sortingOrder = baseOrder + 2;

        Cursor.SetActive(true);
        menuObject.SetActive(true);
        menuObject.GetComponent<MenuComponent>().MoveToFirstOption();
    }

    public void OpenShop(List<Item> availableItems) {
        shopMenu.GetComponent<BuySellMenu>().LoadItems(availableItems);
        OpenSpecificMenu(shopMenu);
    }

    public void OpenDialogOption() {
        OpenSpecificMenu(dialogOption);
    }

    public void OpenConfirmationMenu(Action callback, string confirmationText) {
        confirmationMenu.GetComponent<ConfirmationMenu>().SetActionToConfirm(callback);
        confirmationMenu.GetComponent<ConfirmationMenu>().SetConfirmationText(confirmationText);
        OpenSpecificMenu(confirmationMenu);
    }

    public void OpenAmountSelectMenu(string confirmText, int maxValue, Action<int> callback) {
        AmountSelectMenu amountMenu = amountSelectMenu.GetComponent<AmountSelectMenu>();
        amountMenu.SetConfirmationText(confirmText);
        amountMenu.SetMaxValue(maxValue);
        amountMenu.SetCallback(callback);

        OpenSpecificMenu(amountSelectMenu);
    }

    public void CloseAllMenus() {
        if (MenuStack.Any()) {
            for (int i = MenuStack.Count - 1; i >= 0; i--) {
                if (!MenuStack[i].GetComponent<MenuComponent>().CanBeClosed()) return;
                MenuStack[i].GetComponent<MenuComponent>().CloseMenu();
                MenuStack[i].SetActive(false);
            }
            MenuStack = new List<GameObject>();
        }

        Cursor.SetActive(false);
        GameData.MenuIsOpen = false;
    }

    public void GoBack() {
        if (!MenuStack.Any()) return;
        if (!MenuStack[MenuStack.Count - 1].GetComponent<MenuComponent>().CanBeClosed()) return;

        MenuStack[MenuStack.Count - 1].GetComponent<MenuComponent>().CloseMenu();
        MenuStack[MenuStack.Count - 1].SetActive(false);
        MenuStack.RemoveAt(MenuStack.Count - 1);

        if(MenuStack.Count > 0) {
            MenuStack[MenuStack.Count - 1].SetActive(true);
        }
        else {
            Cursor.SetActive(false);
            GameData.MenuIsOpen = false;
        }
    }

    public MenuComponent CurrentMenu() {
        if (!MenuStack.Any()) return null;

        return MenuStack[MenuStack.Count - 1].GetComponent<MenuComponent>();
    }

    public void MoveDown() {
        CurrentMenu().MoveDown();
    }

    public void MoveUp() {
        CurrentMenu().MoveUp();
    }

    public void MoveLeft() {
        CurrentMenu().MoveLeft();
    }

    public void MoveRight() {
        CurrentMenu().MoveRight();
    }

    public void SelectCurrentOption() {
        CurrentMenu().SelectCurrentOption();
    }
}
