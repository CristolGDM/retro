using System.Collections.Generic;
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

    public new void Start() {
        base.Start();

        PcPreviewSection1.GetComponent<PcPreviewSection>().LoadPc(GameData.getFirstPc());
        PcPreviewSection2.GetComponent<PcPreviewSection>().LoadPc(GameData.getSecondPc());
        PcPreviewSection3.GetComponent<PcPreviewSection>().LoadPc(GameData.getThirdPc());
        PcPreviewSection4.GetComponent<PcPreviewSection>().LoadPc(GameData.getFourthPc());
    }

    protected override void LoadOptions() {
        List<List<GameObject>> tempList = new List<List<GameObject>>();
        if (GameData.getFirstPc() != null) tempList.Add(new List<GameObject> { PcPreviewSection1 });
        if (GameData.getSecondPc() != null) tempList.Add(new List<GameObject> { PcPreviewSection2 });
        if (GameData.getThirdPc() != null) tempList.Add(new List<GameObject> { PcPreviewSection3 });
        if (GameData.getFourthPc() != null) tempList.Add(new List<GameObject> { PcPreviewSection4 });

        SelectableOptions = tempList;

        MoveToFirstOption();
    }

    public void ReadyItem(Item item) {
        itemToApply = item;
    }

    protected override void SelectOption(GameObject option) {
        PlayerCharacter target = option.GetComponent<PcPreviewSection>().GetPc();

        if (target == null) return;
        if (!Inventory.CarriedInventory.ContainsKey(itemToApply.Name)) return;
        if (Inventory.CarriedInventory[itemToApply.Name] <= 0) return;

        //PlayerCharacter[] targets = { target };
        //itemToApply.SetTargets(targets);
        //itemToApply.OnUse();
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
}
