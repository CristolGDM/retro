using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuComponent : MonoBehaviour {

    protected List<List<GameObject>> SelectableOptions = new List<List<GameObject>>();

    [SerializeField]
    GameObject Cursor;

    private int SelectedOptionX = 0;
    private int SelectedOptionY = 0;
    private int[] CursorPosition = { -1, -1 };

    // Use this for initialization
    void Start () {
        LoadOptions();
	}
	
	// Update is called once per frame
	void Update () {
        if (CursorPosition[0] != SelectedOptionX || CursorPosition[1] != SelectedOptionY) {
            Cursor.transform.position = new Vector3(CurrentOption().transform.position.x - 1.6f, CurrentOption().transform.position.y - 0.1f, CurrentOption().transform.position.z);
        }
    }

    protected abstract void LoadOptions();

    private GameObject CurrentOption() {
        return SelectableOptions[SelectedOptionY][SelectedOptionX];
    }

    protected void SelectOption(int x, int y) {
        if (SelectableOptions.Count <= y || SelectableOptions[y].Count <= x) {
            SelectedOptionX = 0;
            SelectedOptionY = 0;
            Cursor.SetActive(false);
        }
        else {
            SelectedOptionX = x;
            SelectedOptionY = y;
            Cursor.SetActive(true);
        }
    }

    public void MoveDown() {
        int y = SelectedOptionY;

        if (y == SelectableOptions.Count - 1) {
            y = 0;
        }
        else {
            y += 1;
        }

        SelectOption(SelectedOptionX, y);
    }

    public void MoveUp() {
        int y = SelectedOptionY;

        if (y == 0) {
            y = SelectableOptions.Count - 1;
        }
        else {
            y -= 1;
        }

        SelectOption(SelectedOptionX, y);
    }

    public void MoveLeft() {
        int x = SelectedOptionX;

        if (x == SelectableOptions[SelectedOptionY].Count - 1) {
            x = 0;
        }
        else {
            x += 1;
        }

        SelectOption(x, SelectedOptionY);
    }

    public void MoveRight() {
        int x = SelectedOptionX;

        if (x == 0) {
            x = SelectableOptions[SelectedOptionY].Count - 1;
        }
        else {
            x -= 1;
        }

        SelectOption(x, SelectedOptionY);
    }
}
