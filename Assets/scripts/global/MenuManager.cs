using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject mainMenu;
    public GameObject MainMenu { get{ return mainMenu; } }
    [SerializeField]
    private GameObject itemMenu;
    public GameObject ItemMenu { get { return itemMenu; } }

    private List<GameObject> AvailableMenus = new List<GameObject>();
    private MenuComponent currentMenu;

    public void Start() {
        AvailableMenus = new List<GameObject> {
            MainMenu,
            ItemMenu
        };
        CloseMenu();
    }

    public void OpenMenu() {
        GameData.MenuIsOpen = true;

        OpenSpecificMenu(MainMenu);
    }

    public void OpenSpecificMenu(GameObject menuObject) {
        for (int i = 0; i < AvailableMenus.Count; i++) {
            if (AvailableMenus[i] == menuObject) {
                AvailableMenus[i].SetActive(true);
                currentMenu = menuObject.GetComponent<MenuComponent>();
            }
            else {
                AvailableMenus[i].SetActive(false);
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
