using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject mainMenu;

    private GameObject leftPart;
    private GameObject rightPart;

    public void openMenu() {
        leftPart = mainMenu.transform.Find("LeftPart").gameObject;
        rightPart = mainMenu.transform.Find("RightPart1").gameObject;
        leftPart.GetComponent<TilemapRenderer>().enabled = true;
        rightPart.GetComponent<TilemapRenderer>().enabled = true;
        GameData.MenuIsOpen = true;
    }
    public void closeMenu() {
        Renderer[] allRenderers = mainMenu.GetComponentsInChildren<TilemapRenderer>();
        foreach (TilemapRenderer childRenderer in allRenderers) {
            childRenderer.enabled = false;
        }
        GameData.MenuIsOpen = false;
    }
}
