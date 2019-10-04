/*
 * Used because I don't want to have to pass components one by one for each Object in the scene
 * But the other option is .Find() which uses the component's name as a string, and it's a pain to refactor
 * So we use this Script to pass component's names to .Find() methods everywhere
 */

public class ComponentNames {
    private static string cursor = "Cursor";
    private static string dialogText = "DialogText";
    private static string dialogBox = "DialogBox";
    private static string dialogMask = "DialogMask";
    private static string playerCharacter = "MainCharacter";
    private static string sceneScripts = "SceneScripts";

    public static string Cursor {
        get { return cursor; }
    }

    public static string DialogText {
        get {
            return dialogText;
        }
    }
    public static string DialogBox {
        get {
            return dialogBox;
        }
    }
    public static string DialogMask {
        get {
            return dialogMask;
        }
    }

    public static string PlayerCharacter {
        get {
            return playerCharacter;
        }
    }


    public static string SceneScripts {
        get {
            return sceneScripts;
        }
    }
}
