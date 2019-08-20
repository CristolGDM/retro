public class GameData {
    private static bool playerCanMove = true;
    private static bool dialogIsOpen = false;

    public static bool PlayerCanMove {
        get {
            return playerCanMove && !dialogIsOpen;
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
}
