using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemTargetMenu : MenuComponent {

    [SerializeField]
    GameObject PcPreviewSection1;
    [SerializeField]
    GameObject PcPreviewSection2;
    [SerializeField]
    GameObject PcPreviewSection3;
    [SerializeField]
    GameObject PcPreviewSection4;
    [SerializeField]
    GameObject ConfirmationMenu;

    private Item itemToApply;
    private PlayerCharacter[] charactersToTarget;
    private List<GameObject> cursors;

    public new void Start() {
        base.Start();

        PcPreviewSection1.GetComponent<PcPreviewSection>().LoadPc(GameData.getFirstPc());
        PcPreviewSection2.GetComponent<PcPreviewSection>().LoadPc(GameData.getSecondPc());
        PcPreviewSection3.GetComponent<PcPreviewSection>().LoadPc(GameData.getThirdPc());
        PcPreviewSection4.GetComponent<PcPreviewSection>().LoadPc(GameData.getFourthPc());
    }

    public new void Update() {
        base.Update();

        if (!itemToApply.NeedTarget) {
            GameObject[] cursorPositions = { PcPreviewSection1, PcPreviewSection2, PcPreviewSection3, PcPreviewSection4 };

            for (int i = 0; i < cursors.Count; i++) {
                cursors[i].transform.position = cursorPositions[i].transform.position;
                cursors[i].SetActive(true);
            }
        }
    }

    protected override void LoadOptions() {
        SelectableOptions = new List<List<GameObject>>();
        charactersToTarget = null;
        cursors = null;
        if (itemToApply.NeedTarget) {
            List<List<GameObject>> tempList = new List<List<GameObject>>();
            if (GameData.getFirstPc() != null) tempList.Add(new List<GameObject> { PcPreviewSection1 });
            if (GameData.getSecondPc() != null) tempList.Add(new List<GameObject> { PcPreviewSection2 });
            if (GameData.getThirdPc() != null) tempList.Add(new List<GameObject> { PcPreviewSection3 });
            if (GameData.getFourthPc() != null) tempList.Add(new List<GameObject> { PcPreviewSection4 });

            SelectableOptions = tempList;

            MoveToFirstOption();
        }
        else {
            cursors = new List<GameObject>();
            menuManager.Cursor.SetActive(true);
            for (int i = 0; i < GameData.getParty().Length; i++) {
                GameObject tempCursor = Instantiate(menuManager.Cursor);
                tempCursor.transform.SetParent(gameObject.transform);
                tempCursor.GetComponent<SpriteRenderer>().sortingOrder = GetComponentInChildren<Canvas>().sortingOrder;
                tempCursor.SetActive(false);
                cursors.Add(Instantiate(menuManager.Cursor));
            }
            menuManager.Cursor.SetActive(false);
        }
    }

    public void ReadyItem(Item item) {
        itemToApply = item;
    }

    protected override void SelectOption(GameObject option) {
        if (!Inventory.CarriedInventory.ContainsKey(itemToApply.Name)) return;
        if (Inventory.CarriedInventory[itemToApply.Name] <= 0) return;

        if (option != null) {
            PlayerCharacter target = option.GetComponent<PcPreviewSection>().GetPc();

            if (target == null) return;

            charactersToTarget = new PlayerCharacter[] { target };
        }
        else {
            charactersToTarget = GameData.getParty();
        }

        ConfirmationMenu.GetComponent<ItemConfirmationMenu>().Init(itemToApply, charactersToTarget);
        ConfirmationMenu.GetComponent<ItemConfirmationMenu>().LoadYesNoActions(OnYesFromConfirm, OnNoFromConfirm);
        menuManager.OpenSpecificMenu(ConfirmationMenu);
    }

    public override void PlaceCursorOnOption(GameObject option) {
        PcPreviewSection pcprev = option.GetComponent<PcPreviewSection>();
        if (pcprev == null) { base.PlaceCursorOnOption(option); }
        else {
            RectTransform rectTrans = pcprev.pcName.GetComponent<RectTransform>();
            float cursorLeftOffset = ((1.4f * rectTrans.rect.width) / 120) - 0.1f;
            menuManager.Cursor.transform.position = new Vector3(CurrentOption().transform.position.x - cursorLeftOffset, CurrentOption().transform.position.y - 0.1f, CurrentOption().transform.position.z);
        }
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
