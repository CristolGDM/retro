using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class MenuComponent : MonoBehaviour {

    protected List<List<GameObject>> SelectableOptions = new List<List<GameObject>>();

    private GameObject Cursor;

    private int SelectedOptionX = 0;
    private int SelectedOptionY = 0;
    protected MenuManager menuManager;

    // Use this for initialization
    public void Start () {

        menuManager = GameObject.Find(ComponentNames.SceneScripts).GetComponent<MenuManager>();
        LoadOptions();

        Cursor = menuManager.Cursor;
	}
	
	// Update is called once per frame
	protected void Update () {
        if (Cursor == null) Cursor = menuManager.Cursor;

        float cursorLeftOffset = (1.4f * CurrentOption().GetComponent<RectTransform>().rect.width / 120) + 0.1f;
        Cursor.transform.position = new Vector3(CurrentOption().transform.position.x - cursorLeftOffset, CurrentOption().transform.position.y - 0.1f, CurrentOption().transform.position.z);
    }

    protected abstract void LoadOptions();
    protected abstract void SelectOption(GameObject option);

    public void SelectCurrentOption() {
        SelectOption(CurrentOption());
    }
    public void SelectFirstOption() {
        MoveToOption(0, 0);
    }

    protected GameObject CurrentOption() {
        if (!SelectableOptions.Any() || !SelectableOptions[SelectedOptionY].Any()) return null;

        return SelectableOptions[SelectedOptionY][SelectedOptionX];
    }

    protected void MoveToOption(int x, int y) {
        if (Cursor == null) return;
        if (SelectableOptions.Any()
          && SelectableOptions[y].Any()
          && SelectableOptions.Count > y
          && SelectableOptions[y].Count > x) {
            SelectedOptionX = x;
            SelectedOptionY = y;
            Cursor.SetActive(true);
        }
        else {
            SelectedOptionX = -1;
            SelectedOptionY = -1;
            Cursor.SetActive(false);
        }
    }

    public void MoveDown() {
        int y = SelectedOptionY;

        if (!SelectableOptions.Any()) {
            y = -1;
        }
        else if (y == SelectableOptions.Count - 1) {
            y = 0;
        }
        else {
            y += 1;
        }

        int x = Math.Min(SelectedOptionX, SelectableOptions[y].Count -1);

        MoveToOption(x, y);
    }

    public void MoveUp() {
        int y = SelectedOptionY;

        if (!SelectableOptions.Any()) {
            y = -1;
        }
        else if (y == 0) {
            y = SelectableOptions.Count - 1;
        }
        else {
            y -= 1;
        }

        MoveToOption(SelectedOptionX, y);
    }

    public void MoveLeft() {
        int x = SelectedOptionX;

        if (!SelectableOptions.Any() || !SelectableOptions[SelectedOptionY].Any()) {
            x = -1;
        }
        else if (x == 0) {
            x = SelectableOptions[SelectedOptionY].Count - 1;
        }
        else {
            x -= 1;
        }

        MoveToOption(x, SelectedOptionY);
    }

    public void MoveRight() {
        int x = SelectedOptionX;

        if (!SelectableOptions.Any() || !SelectableOptions[SelectedOptionY].Any()) {
            x = -1;
        }
        else if (x == SelectableOptions[SelectedOptionY].Count - 1) {
            x = 0;
        }
        else {
            x += 1;
        }

        MoveToOption(x, SelectedOptionY);
    }
}
