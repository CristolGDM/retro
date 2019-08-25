using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacters {

    private static PlayerCharacter mainCharacter = new PlayerCharacter("Mikasuke", "test-Sheet", 98, 100, 1, "0001");
    public static PlayerCharacter MainCharacter { get { return mainCharacter; } }
}
