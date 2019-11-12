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

    public new void Update() {
        base.Update();
    }

    protected override void LoadOptions() {
        SelectableOptions.Add(new List<GameObject> { PcPreviewSection1 });
        SelectableOptions.Add(new List<GameObject> { PcPreviewSection2 });
        SelectableOptions.Add(new List<GameObject> { PcPreviewSection3 });
        SelectableOptions.Add(new List<GameObject> { PcPreviewSection4 });
    }

    protected override void SelectOption(GameObject option) {
    }
}
