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

    Sprite[] sprites;

    public void loadPc(PlayerCharacter character) {
        CancelInvoke();
        if (character != null) {
            gameObject.GetComponentInChildren<Canvas>().enabled = true;
            pcName.text = character.characterName;
            pcPv.text = character.currentPv + "/" + character.maxPv;
            pcLv.text = "Lv." + character.level;
            pcJob.text = character.job;

            pcSprite.GetComponent<SpriteRenderer>().enabled = true;
            sprites = Resources.LoadAll<Sprite>("sprites/spritesheets/" + character.spriteSheetName);
            pcSprite.GetComponent<SpriteRenderer>().sprite = sprites[0];

            float startMoving = Random.Range(0f, 0.2f);
            float moveInterval = Random.Range(0.3f, 0.5f);
            InvokeRepeating("animateSprite", startMoving, moveInterval);
        }
        else {
            gameObject.GetComponentInChildren<Canvas>().enabled = false;
            pcName.text = "";
            pcPv.text = "";
            pcLv.text = "";
            pcJob.text = "";
            pcSprite.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void animateSprite() {
        if(pcSprite.GetComponent<SpriteRenderer>().sprite == sprites[0]) {
            pcSprite.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else {
            pcSprite.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
    }
}
