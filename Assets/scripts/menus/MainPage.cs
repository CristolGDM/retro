using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MainPage : MonoBehaviour {
    [SerializeField]
    GameObject MenuBackground;

    [SerializeField]
    GameObject MainMenuText;

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


    public void Open() {
        MenuBackground.GetComponent<TilemapRenderer>().enabled = true;
        MainMenuText.GetComponent<Canvas>().enabled = true;
        PcSection1.GetComponentInChildren<Canvas>().enabled = true;
        PcSection1.GetComponentInChildren<SpriteRenderer>().enabled = true;
        PcSection2.GetComponentInChildren<Canvas>().enabled = true;
        PcSection2.GetComponentInChildren<SpriteRenderer>().enabled = true;
        PcSection3.GetComponentInChildren<Canvas>().enabled = true;
        PcSection3.GetComponentInChildren<SpriteRenderer>().enabled = true;
        PcSection4.GetComponentInChildren<Canvas>().enabled = true;
        PcSection4.GetComponentInChildren<SpriteRenderer>().enabled = true;

        PcSection1.GetComponent<PcPreviewSection>().loadPc(GameData.getFirstPc());
        PcSection2.GetComponent<PcPreviewSection>().loadPc(GameData.getSecondPc());
        PcSection3.GetComponent<PcPreviewSection>().loadPc(GameData.getThirdPc());
        PcSection4.GetComponent<PcPreviewSection>().loadPc(GameData.getFourthPc());
    }

    public void Close() {
        MenuBackground.GetComponent<TilemapRenderer>().enabled = false;
        MainMenuText.GetComponent<Canvas>().enabled = false;
        PcSection1.GetComponentInChildren<Canvas>().enabled = false;
        PcSection1.GetComponentInChildren<SpriteRenderer>().enabled = false;
        PcSection2.GetComponentInChildren<Canvas>().enabled = false;
        PcSection2.GetComponentInChildren<SpriteRenderer>().enabled = false;
        PcSection3.GetComponentInChildren<Canvas>().enabled = false;
        PcSection3.GetComponentInChildren<SpriteRenderer>().enabled = false;
        PcSection4.GetComponentInChildren<Canvas>().enabled = false;
        PcSection4.GetComponentInChildren<SpriteRenderer>().enabled = false;
    }

    public List<List<GameObject>> GetOptions() {
        List<List<GameObject>> SelectableOptions = new List<List<GameObject>>();
        SelectableOptions.Add(new List<GameObject> { ItemOption });
        SelectableOptions.Add(new List<GameObject> { MagicOption });
        SelectableOptions.Add(new List<GameObject> { StatusOption });

        return SelectableOptions;
    }
}
