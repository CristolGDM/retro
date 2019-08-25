using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameData {
    private static bool playerCanMove = true;
    private static bool dialogIsOpen = false;
    private static bool playerCanTransition = true;
    private static bool menuIsOpen = false;
    private static List<PlayerCharacter> availableCharacters = new List<PlayerCharacter>();
    private static List<PlayerCharacter> currentParty = new List<PlayerCharacter>();

    public static bool PlayerCanMove {
        get {
            return playerCanMove && !dialogIsOpen && !menuIsOpen;
        }
        set {
            playerCanMove = value;
        }
    }

    public static bool DialogIsOpen {
        get {
            return dialogIsOpen;
        }
        set {
            dialogIsOpen = value;
        }
    }

    public static bool PlayerCanTransition {
        get {
            return playerCanTransition;
        }
        set {
            playerCanTransition = value;
        }
    }

    public static bool MenuIsOpen {
        get {
            return menuIsOpen;
        }
        set {
            menuIsOpen = value;
        }
    }

    public static PlayerCharacter getCharacter(string charId) {
        PlayerCharacter returnChar = null;

        foreach(PlayerCharacter pc in availableCharacters) {
            if(pc.CharId == charId) {
                returnChar = pc;
                break;
            }
        }

        return returnChar;
    }

    public static void addNewCharacter(PlayerCharacter newChar) {
        if (getCharacter(newChar.CharId) == null) {
            availableCharacters.Add(newChar);
        }

    }

    public static void addCharacterToParty(PlayerCharacter newChar) {
        if (newChar != null && currentParty.Count < 4) {
            bool isAlreadyInParty = false;
            for (int i = 0; i < currentParty.Count; i++) {
                if (currentParty[i].CharId == newChar.CharId) {
                    isAlreadyInParty = true;
                    break;
                }
            }
            if(!isAlreadyInParty) currentParty.Add(newChar);
        }
    }

    public static PlayerCharacter getPc(int whichPc) {
        if (whichPc < 4) {
            return currentParty[whichPc - 1];
        }
        return null;
    }

    public static void removeCharacterFromParty(string charId) {
        for (int i = 0; i < currentParty.Count; i++) {
            if(currentParty[i].CharId == charId) {
                currentParty.RemoveAt(i);
            }
        }
    }
}
