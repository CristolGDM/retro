using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MainPage : MonoBehaviour {
    [SerializeField]
    GameObject LeftPart;
    [SerializeField]
    GameObject RightPart;

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

    public void Open() {
        LeftPart.GetComponent<TilemapRenderer>().enabled = true;
        RightPart.GetComponent<TilemapRenderer>().enabled = true;
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
}
