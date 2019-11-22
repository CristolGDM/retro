using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GameData {
    private static bool playerCanMove = true;
    private static bool playerCanTransition = true;
    public static bool inputBypassedByEventManager;
    public static bool DialogIsOpen { get; set; }
    public static bool MenuIsOpen { get; set; }
    private static List<PlayerCharacter> availableCharacters = new List<PlayerCharacter>();
    private static List<PlayerCharacter> currentParty = new List<PlayerCharacter>();

    public static bool PlayerCanMove {
        get {
            return playerCanMove && !DialogIsOpen && !MenuIsOpen;
        }
        set {
            playerCanMove = value;
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

    public static void AddNewCharacter(PlayerCharacter newChar) {
        if (getCharacter(newChar.CharId) == null) {
            availableCharacters.Add(newChar);
        }

    }

    public static void AddCharacterToParty(PlayerCharacter newChar) {
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

    public static PlayerCharacter GetFirstPc() {
        return currentParty[0];
    }

    public static PlayerCharacter GetSecondPc() {
        if (currentParty.Count >= 2) {
            return currentParty[1];
        }
        return null;
    }

    public static PlayerCharacter GetThirdPc() {
        if (currentParty.Count >= 3) {
            return currentParty[2];
        }
        return null;
    }

    public static PlayerCharacter GetFourthPc() {
        if (currentParty.Count == 4) {
            return currentParty[3];
        }
        return null;
    }

    public static PlayerCharacter[] GetParty() {
        return currentParty.ToArray();
    }

    public static void RemoveCharacterFromParty(string charId) {
        for (int i = 0; i < currentParty.Count; i++) {
            if(currentParty[i].CharId == charId) {
                currentParty.RemoveAt(i);
            }
        }
    }
}
