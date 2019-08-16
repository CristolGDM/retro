/*
 * Used because I don't want to have to pass components one by one for each Object in the scene
 * But the other option is .Find() which uses the component's name as a string, and it's a pain to refactor
 * So we use this Script to pass component's names to .Find() methods everywhere
 */

public class ComponentNames {
    private static string dialogBoxText = "DialogBoxText";
    private static string dialogBoxBackground = "DialogBoxBackground";

    public static string DialogBoxText {
        get {
            return dialogBoxText;
        }
    }
    public static string DialogBoxBackground {
        get {
            return dialogBoxBackground;
        }
    }
}
