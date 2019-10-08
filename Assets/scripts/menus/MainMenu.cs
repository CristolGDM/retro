using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MenuComponent {

    [SerializeField]
    GameObject PcSection1;
    [SerializeField]
    GameObject PcSection2;
    [SerializeField]
    GameObject PcSection3;
    [SerializeField]
    GameObject PcSection4;

    [SerializeField]
    GameObject ItemOption;
    [SerializeField]
    GameObject MagicOption;
    [SerializeField]
    GameObject StatusOption;

    public new void Start() {
        base.Start();

        PcSection1.GetComponent<PcPreviewSection>().loadPc(GameData.getFirstPc());
        PcSection2.GetComponent<PcPreviewSection>().loadPc(GameData.getSecondPc());
        PcSection3.GetComponent<PcPreviewSection>().loadPc(GameData.getThirdPc());
        PcSection4.GetComponent<PcPreviewSection>().loadPc(GameData.getFourthPc());
    }

    protected override void LoadOptions() {
        List<List<GameObject>> Options = new List<List<GameObject>>();
        Options.Add(new List<GameObject> { ItemOption });
        Options.Add(new List<GameObject> { MagicOption });
        Options.Add(new List<GameObject> { StatusOption });

        SelectableOptions = Options;
        SelectOption(0, 0);
    }

    protected override void SelectOption(GameObject option) {
        if(option == ItemOption) {
            menuManager.OpenSpecificMenu(menuManager.ItemMenu);
            return;
        }
        else if(option == MagicOption) {
            Debug.Log("Trying to open Magic menu");
            return;
        }
        else if(option == StatusOption) {
            Debug.Log("Trying to open stats menu");
            return;
        }
    }
}
