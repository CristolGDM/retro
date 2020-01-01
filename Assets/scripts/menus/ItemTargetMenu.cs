using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemTargetMenu : MenuComponent {

    [SerializeField]
    GameObject PcPreviewSection1 = null;
    [SerializeField]
    GameObject PcPreviewSection2 = null;
    [SerializeField]
    GameObject PcPreviewSection3 = null;
    [SerializeField]
    GameObject PcPreviewSection4 = null;
    [SerializeField]
    GameObject ConfirmationMenu = null;

    private Item itemToApply;
    private PlayerCharacter[] charactersToTarget;
    private List<GameObject> cursors;

    public new void Start() {
        base.Start();

        PcPreviewSection1.GetComponent<PcPreviewSection>().LoadPc(GameData.GetFirstPc());
        PcPreviewSection2.GetComponent<PcPreviewSection>().LoadPc(GameData.GetSecondPc());
        PcPreviewSection3.GetComponent<PcPreviewSection>().LoadPc(GameData.GetThirdPc());
        PcPreviewSection4.GetComponent<PcPreviewSection>().LoadPc(GameData.GetFourthPc());
    }

    public override void CloseMenu() {
        CancelInvoke();
        if (cursors != null) {
            Transform tempParent = new GameObject().transform;
            foreach (GameObject cursor in cursors) {
                Destroy(cursor);
            }
        }
    }

    public new void Update() {
        base.Update();

        if (!itemToApply.NeedTarget) {
            GameObject[] cursorPositions = { PcPreviewSection1, PcPreviewSection2, PcPreviewSection3, PcPreviewSection4 };

            for (int i = 0; i < cursors.Count; i++) {
                PlaceSpecificCursorOnSpecificOption(cursors[i], cursorPositions[i]);
            }
        }
    }

    protected override void LoadOptions() {
        SelectableOptions = new List<List<GameObject>>();
        charactersToTarget = null;
        cursors = new List<GameObject>();
        if (itemToApply.NeedTarget) {
            List<List<GameObject>> tempList = new List<List<GameObject>>();
            if (GameData.GetFirstPc() != null) tempList.Add(new List<GameObject> { PcPreviewSection1 });
            if (GameData.GetSecondPc() != null) tempList.Add(new List<GameObject> { PcPreviewSection2 });
            if (GameData.GetThirdPc() != null) tempList.Add(new List<GameObject> { PcPreviewSection3 });
            if (GameData.GetFourthPc() != null) tempList.Add(new List<GameObject> { PcPreviewSection4 });

            SelectableOptions = tempList;

            MoveToFirstOption();
        }
        else {
            List<GameObject> tempCursors = new List<GameObject>();
            menuManager.Cursor.SetActive(true);
            for (int i = 0; i < GameData.GetParty().Length; i++) {
                GameObject tempCursor = Instantiate(menuManager.Cursor);
                tempCursor.transform.SetParent(gameObject.transform);
                tempCursor.GetComponent<SpriteRenderer>().sortingOrder = GetComponentInChildren<Canvas>().sortingOrder;
                tempCursor.SetActive(true);
                tempCursors.Add(tempCursor);
            }
            cursors = tempCursors;
            menuManager.Cursor.SetActive(false);
            InvokeRepeating("SwitchCursorsVisibility", 0f, 0.05f);
        }
    }

    public void ReadyItem(Item item) {
        itemToApply = item;
    }

    public void SwitchCursorsVisibility() {
        foreach (GameObject cursor in cursors) {
            cursor.SetActive(!cursor.activeSelf);
        }
    }

    protected override void SelectOption(GameObject option) {
        if (Inventory.GetCarriedAmount(itemToApply) <= 0) return;

        if (option != null) {
            PlayerCharacter target = option.GetComponent<PcPreviewSection>().GetPc();

            if (target == null) return;

            charactersToTarget = new PlayerCharacter[] { target };
        }
        else {
            charactersToTarget = GameData.GetParty();
        }

        ConfirmationMenu.GetComponent<ItemConfirmationMenu>().Init(itemToApply, charactersToTarget);
        ConfirmationMenu.GetComponent<ItemConfirmationMenu>().LoadYesNoActions(OnYesFromConfirm, OnNoFromConfirm);
        menuManager.OpenSpecificMenu(ConfirmationMenu);
    }

    private void OnYesFromConfirm() {
        itemToApply.SetTargets(charactersToTarget);
        itemToApply.OnUse();

        menuManager.GoBack();
    }

    private void OnNoFromConfirm() {
        menuManager.GoBack();
    }
}
