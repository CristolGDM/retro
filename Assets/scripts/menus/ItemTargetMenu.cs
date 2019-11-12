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

    public new void Start() {
        base.Start();

        PcPreviewSection1.GetComponent<PcPreviewSection>().LoadPc(GameData.getFirstPc());
        PcPreviewSection2.GetComponent<PcPreviewSection>().LoadPc(GameData.getSecondPc());
        PcPreviewSection3.GetComponent<PcPreviewSection>().LoadPc(GameData.getThirdPc());
        PcPreviewSection4.GetComponent<PcPreviewSection>().LoadPc(GameData.getFourthPc());
    }

    protected override void LoadOptions() {
        if (GameData.getFirstPc() != null) SelectableOptions.Add(new List<GameObject> { PcPreviewSection1 });
        if (GameData.getSecondPc() != null) SelectableOptions.Add(new List<GameObject> { PcPreviewSection2 });
        if (GameData.getThirdPc() != null) SelectableOptions.Add(new List<GameObject> { PcPreviewSection3 });
        if (GameData.getFourthPc() != null) SelectableOptions.Add(new List<GameObject> { PcPreviewSection4 });

        MoveToFirstOption();
    }

    protected override void SelectOption(GameObject option) {
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
