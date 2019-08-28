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
        if (character != null) {
            gameObject.GetComponentInChildren<Canvas>().enabled = true;
            pcName.text = character.characterName;
            pcPv.text = character.currentPv + "/" + character.maxPv;
            pcLv.text = "Lv." + character.level;
            pcJob.text = character.job;

            pcSprite.GetComponent<SpriteRenderer>().enabled = true;
            sprites = Resources.LoadAll<Sprite>("sprites/spritesheets/" + character.spriteSheetName);
            pcSprite.GetComponent<SpriteRenderer>().sprite = sprites[0];
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
}
