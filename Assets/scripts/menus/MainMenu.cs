using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MenuComponent {

    [SerializeField]
    private GameObject PcSection1 = null;
    [SerializeField]
    private GameObject PcSection2 = null;
    [SerializeField]
    private GameObject PcSection3 = null;
    [SerializeField]
    private GameObject PcSection4 = null;

    [SerializeField]
    private GameObject ItemOption = null;
    [SerializeField]
    private GameObject MagicOption = null;
    [SerializeField]
    private GameObject StatusOption = null;

    [SerializeField]
    GameObject ItemMenu = null;

    public new void Start() {
        base.Start();

        PcSection1.GetComponent<PcPreviewSection>().LoadPc(GameData.GetFirstPc());
        PcSection2.GetComponent<PcPreviewSection>().LoadPc(GameData.GetSecondPc());
        PcSection3.GetComponent<PcPreviewSection>().LoadPc(GameData.GetThirdPc());
        PcSection4.GetComponent<PcPreviewSection>().LoadPc(GameData.GetFourthPc());
    }

    protected override void LoadOptions() {
        List<List<GameObject>> Options = new List<List<GameObject>> {
            new List<GameObject> { ItemOption },
            new List<GameObject> { MagicOption },
            new List<GameObject> { StatusOption }
        };

        SelectableOptions = Options;
        MoveToOption(0, 0);
    }

    protected override void SelectOption(GameObject option) {
        if(option == ItemOption) {
            menuManager.OpenSpecificMenu(ItemMenu);
        }
        else if(option == MagicOption) {
            Debug.Log("Trying to open Magic menu");
        }
        else if(option == StatusOption) {
            Debug.Log("Trying to open stats menu");
        }
    }
}
