using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject MainMenu;

    [SerializeField]
    GameObject Cursor;

    private List<List<GameObject>> SelectableOptions = new List<List<GameObject>>();
    private int SelectedOptionX = 0;
    private int SelectedOptionY = 0;
    private List<GameObject> AvailableMenus = new List<GameObject>();

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
                LoadOptions(MainMenu.GetComponent<MainPage>().GetOptions());
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

    public void LoadOptions(List<List<GameObject>> options) {
        SelectableOptions = options;
        SelectOption(0, 0);
    }

    private GameObject CurrentOption() {
        return SelectableOptions[SelectedOptionY][SelectedOptionX];
    }

    private void SelectOption(int x, int y) {
        if (SelectableOptions.Count <= y || SelectableOptions[y].Count <= x) {
            SelectedOptionX = 0;
            SelectedOptionY = 0;
            Cursor.SetActive(false);
        } else {
            Cursor.SetActive(true);
            SelectedOptionX = x;
            SelectedOptionY = y;
            Cursor.transform.position = new Vector3(CurrentOption().transform.position.x - 1.6f, CurrentOption().transform.position.y - 0.1f, CurrentOption().transform.position.z);
        }
    }

    public void MoveDown() {
        int y = SelectedOptionY;

        if (y == SelectableOptions.Count - 1) {
            y = 0;
        } else {
            y += 1;
        }

        SelectOption(SelectedOptionX, y);
    }

    public void MoveUp() {
        int y = SelectedOptionY;

        if (y == 0) {
            y = SelectableOptions.Count - 1;
        } else {
            y -= 1;
        }

        SelectOption(SelectedOptionX, y);
    }

    public void MoveLeft() {
        int x = SelectedOptionX;

        if (x == SelectableOptions[SelectedOptionY].Count - 1) {
            x = 0;
        } else {
            x += 1;
        }

        SelectOption(x, SelectedOptionY);
    }

    public void MoveRight() {
        int x = SelectedOptionX;

        if (x == 0) {
            x = SelectableOptions[SelectedOptionY].Count - 1;
        } else {
            x -= 1;
        }

        SelectOption(x, SelectedOptionY);
    }
}
