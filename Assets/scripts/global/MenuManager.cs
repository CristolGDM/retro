using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject mainMenu;

    public void Start() {
        closeMenu();
    }

    public void openMenu() {
        mainMenu.GetComponent<MainPage>().Open();
        GameData.MenuIsOpen = true;
    }
    public void closeMenu() {
        TilemapRenderer[] allRenderers = mainMenu.GetComponentsInChildren<TilemapRenderer>();
        Canvas[] allText = mainMenu.GetComponentsInChildren<Canvas>();
        SpriteRenderer[] allSprites = mainMenu.GetComponentsInChildren<SpriteRenderer>();
        foreach (TilemapRenderer childRenderer in allRenderers) {
            childRenderer.enabled = false;
        }
        foreach (Canvas text in allText) {
            text.enabled = false;
        }
        foreach (SpriteRenderer sprite in allSprites) {
            sprite.enabled = false;
        }
        GameData.MenuIsOpen = false;
    }
}
