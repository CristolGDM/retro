using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter {
    public string characterName;
    public string spriteSheetName;
    public int currentPv;
    public int maxPv;
    public int level;
    public string job;
    private string charId;

    public PlayerCharacter(
        string aCharacterName, 
        string aSpriteSheetName, 
        int aCurrentPv, 
        int aMaxPv, 
        int aLevel,
        string aJob,
        string aCharId) {

        characterName = aCharacterName;
        spriteSheetName = aSpriteSheetName;
        currentPv = aCurrentPv;
        maxPv = aMaxPv;
        level = aLevel;
        job = aJob;
        charId = aCharId;
    }

    public string CharId {
        get {
            return charId;
        }
    }
}
