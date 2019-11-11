using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject mainMenu;
    public GameObject MainMenu { get{ return mainMenu; } }

    public GameObject Cursor;

    private List<GameObject> MenuStack = new List<GameObject>();

    public void Start() {
        CloseAllMenus();
    }

    public void OpenMenu() {
        GameData.MenuIsOpen = true;

        OpenSpecificMenu(MainMenu);
    }

    public void OpenSpecificMenu(GameObject menuObject) {
        Cursor.SetActive(true);
        menuObject.SetActive(true);
        MenuStack.Add(menuObject);
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
        Cursor.GetComponent<SpriteRenderer>().sortingOrder = baseOrder + 1;
    }

    public void CloseAllMenus() {
        if (MenuStack.Any()) {
            for (int i = MenuStack.Count - 1; i == 0; i--) {
                MenuStack[i].SetActive(false);
            }
        }

        Cursor.SetActive(false);
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
                Cursor.SetActive(false);
                GameData.MenuIsOpen = false;
            }
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
