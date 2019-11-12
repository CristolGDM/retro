using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PcPreviewSection : MonoBehaviour {

    [SerializeField]
    Text pcName;

    [SerializeField]
    Text pcPv;

    [SerializeField]
    Text pcLv;

    [SerializeField]
    Text pcJob;

    [SerializeField]
    GameObject pcSprite;

    private Sprite[] sprites;
    private PlayerCharacter thisCharacter;

    public void Update() {
        LoadPcData();
    }

    public void LoadPc(PlayerCharacter character) {
        CancelInvoke();
        thisCharacter = character;

        float startMoving = Random.Range(0f, 0.2f);
        float moveInterval = Random.Range(0.3f, 0.5f);
        InvokeRepeating("AnimateSprite", startMoving, moveInterval);
    }

    private void AnimateSprite() {
        if (thisCharacter == null) return;
        if (sprites == null) return;
        if (pcSprite == null) return;

        if(pcSprite.GetComponent<SpriteRenderer>().sprite == sprites[0]) {
            pcSprite.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else {
            pcSprite.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
    }

    private void LoadPcData() {
        if (thisCharacter != null) {
            gameObject.GetComponentInChildren<Canvas>().enabled = true;
            if (pcName != null) pcName.text = thisCharacter.characterName;
            if (pcPv != null) pcPv.text = thisCharacter.currentPv + "/" + thisCharacter.maxPv;
            if (pcLv != null) pcLv.text = "Lv." + thisCharacter.level;
            if (pcJob != null) pcJob.text = thisCharacter.job;

            if (pcSprite != null) pcSprite.GetComponent<SpriteRenderer>().enabled = true;
            sprites = Resources.LoadAll<Sprite>("sprites/spritesheets/" + thisCharacter.spriteSheetName);

        } else {
            gameObject.GetComponentInChildren<Canvas>().enabled = false;
            if (pcName != null) pcName.text = "";
            if (pcPv != null) pcPv.text = "";
            if (pcLv != null) pcLv.text = "";
            if (pcJob != null) pcJob.text = "";
            if (pcSprite != null) pcSprite.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
