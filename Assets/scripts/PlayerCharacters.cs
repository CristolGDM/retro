using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacters {

    private static PlayerCharacter mainCharacter = new PlayerCharacter("Mikasuke", "test-Sheet", 98, 100, 1, "Samurai", "0001");
    public static PlayerCharacter MainCharacter { get { return mainCharacter; } }

    private static PlayerCharacter yurgurine = new PlayerCharacter("Yurgurine", "npc-Sheet", 80, 80, 3, "Wise man", "0002");
    public static PlayerCharacter Yurgurine { get { return yurgurine; } }
}
