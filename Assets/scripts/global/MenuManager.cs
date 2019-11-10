using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject mainMenu;
    public GameObject MainMenu { get{ return mainMenu; } }

    private List<GameObject> MenuStack = new List<GameObject>();
    private MenuComponent currentMenu;

    public void Start() {
        CloseAllMenus();
    }

    public void OpenMenu() {
        GameData.MenuIsOpen = true;

        OpenSpecificMenu(MainMenu);
    }

    public void OpenSpecificMenu(GameObject menuObject) {
        if (MenuStack.Any()) {
            MenuStack[MenuStack.Count - 1].SetActive(false);
        }
        menuObject.SetActive(true);
        currentMenu = menuObject.GetComponent<MenuComponent>();
        MenuStack.Add(menuObject);
    }

    public void CloseAllMenus() {
        if (MenuStack.Any()) {
            for (int i = MenuStack.Count - 1; i == 0; i--) {
                MenuStack[i].SetActive(false);
            }
        }

        GameData.MenuIsOpen = false;
    }

    public void GoBack() {
        if (MenuStack.Any()) {
            MenuStack[MenuStack.Count - 1].SetActive(false);
            MenuStack.RemoveAt(MenuStack.Count - 1);

            if(MenuStack.Count > 0) {
                MenuStack[MenuStack.Count - 1].SetActive(true);
            }
            else {
                GameData.MenuIsOpen = false;
            }
        }
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
