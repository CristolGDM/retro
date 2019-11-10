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
            pcName.text = thisCharacter.characterName;
            pcPv.text = thisCharacter.currentPv + "/" + thisCharacter.maxPv;
            pcLv.text = "Lv." + thisCharacter.level;
            pcJob.text = thisCharacter.job;

            pcSprite.GetComponent<SpriteRenderer>().enabled = true;
            sprites = Resources.LoadAll<Sprite>("sprites/spritesheets/" + thisCharacter.spriteSheetName);

        } else {
            gameObject.GetComponentInChildren<Canvas>().enabled = false;
            pcName.text = "";
            pcPv.text = "";
            pcLv.text = "";
            pcJob.text = "";
            pcSprite.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
