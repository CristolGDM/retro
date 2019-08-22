using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject MainMenu;

    public void openMenu() {
        MainMenu.GetComponent<TilemapRenderer>().enabled = true;
        GameData.MenuIsOpen = true;
    }
    public void closeMenu() {
        MainMenu.GetComponent<TilemapRenderer>().enabled = false;
        GameData.MenuIsOpen = false;
    }
}
