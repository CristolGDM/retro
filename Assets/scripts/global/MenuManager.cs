using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject mainMenu;

    private GameObject leftPart;
    private GameObject rightPart;

    public void Start() {
        closeMenu();
    }

    public void openMenu() {
        leftPart = mainMenu.transform.Find("LeftPart").gameObject;
        rightPart = mainMenu.transform.Find("RightPart4").gameObject;
        leftPart.GetComponent<TilemapRenderer>().enabled = true;
        rightPart.GetComponent<TilemapRenderer>().enabled = true;
        mainMenu.transform.Find("GameMenuText").gameObject.GetComponent<Canvas>().enabled = true;
        GameData.MenuIsOpen = true;
    }
    public void closeMenu() {
        TilemapRenderer[] allRenderers = mainMenu.GetComponentsInChildren<TilemapRenderer>();
        Canvas[] allText = mainMenu.GetComponentsInChildren<Canvas>();
        foreach (TilemapRenderer childRenderer in allRenderers) {
            childRenderer.enabled = false;
        }
        foreach (Canvas text in allText) {
            text.enabled = false;
        }
        GameData.MenuIsOpen = false;
    }
}
