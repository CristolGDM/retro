using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter {
    public string characterName;
    public string spriteSheetName;
    public int currentPv;
    public int maxPv;
    public int level;
    private string charId;

    public PlayerCharacter(string aCharacterName, string aSpriteSheetName, int aCurrentPv, int aMaxPv, int aLevel, string aCharId) {

        characterName = aCharacterName;
        spriteSheetName = aSpriteSheetName;
        currentPv = aCurrentPv;
        maxPv = aMaxPv;
        level = aLevel;
        charId = aCharId;
    }

    public string CharId {
        get {
            return charId;
        }
    }
}
