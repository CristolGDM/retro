using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject MainMenu;

    private List<GameObject> AvailableMenus = new List<GameObject>();
    private MenuComponent currentMenu;

    public void Start() {
        AvailableMenus = new List<GameObject> {
            MainMenu
        };
        CloseMenu();
    }

    public void OpenMenu() {
        GameData.MenuIsOpen = true;

        OpenSpecificMenu(MainMenu);
    }

    public void OpenSpecificMenu(GameObject menuObject) {
        for (int i = 0; i < AvailableMenus.Count; i++) {
            if(AvailableMenus[i] == menuObject) {
                menuObject.SetActive(true);
                currentMenu = menuObject.GetComponent<MenuComponent>();
            }
            else {
                menuObject.SetActive(false);
            }
        }
    }

    public void CloseMenu() {
        for (int i = 0; i < AvailableMenus.Count; i++) {
            AvailableMenus[i].SetActive(false);
        }

        GameData.MenuIsOpen = false;
    }

    public void MoveDown() {
        currentMenu.MoveDown();
    }

    public void MoveUp() {
        currentMenu.MoveUp();
    }

    public void MoveLeft() {
        currentMenu.MoveLeft();
    }

    public void MoveRight() {
        currentMenu.MoveRight();
    }

    public void SelectCurrentOption() {
        currentMenu.SelectCurrentOption();
    }
}
