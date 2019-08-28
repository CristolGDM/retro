using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacters {

    private static PlayerCharacter mainCharacter = new PlayerCharacter(aCharacterName: "Mikasuke", aSpriteSheetName: "test-Sheet", aCurrentPv: 98, aMaxPv: 100, aLevel: 1, aJob: "Samurai", aCharId: "0001");
    public static PlayerCharacter MainCharacter { get { return mainCharacter; } }

    private static PlayerCharacter yurgurine = new PlayerCharacter(aCharacterName: "Yurgurine", aSpriteSheetName: "npc-Sheet", aCurrentPv: 80, aMaxPv: 80, aLevel: 2, aJob: "Wise man", aCharId: "0002");
    public static PlayerCharacter Yurgurine { get { return yurgurine; } }
}
