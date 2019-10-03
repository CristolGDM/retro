using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject MainMenu;

    [SerializeField]
    GameObject Cursor;

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
        Cursor.SetActive(true);

        OpenSpecificMenu(MainMenu);
    }

    public void OpenSpecificMenu(GameObject menuObject) {
        for (int i = 0; i < AvailableMenus.Count; i++) {
            if(AvailableMenus[i] == menuObject) {
                menuObject.SetActive(true);
                currentMenu = menuObject.GetComponent<MenuComponent>();
                //LoadOptions(MainMenu.GetComponent<MainPage>().GetOptions());
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

        Cursor.SetActive(false);
        GameData.MenuIsOpen = false;
    }

    //public void LoadOptions(List<List<GameObject>> options) {
    //    SelectableOptions = options;
    //    SelectOption(0, 0);
    //}

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
}
