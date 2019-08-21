public class GameData {
    private static bool playerCanMove = true;
    private static bool dialogIsOpen = false;
    private static bool playerCanTransition = true;

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

    public static bool PlayerCanTransition {
        get {
            return playerCanTransition;
        }
        set {
            playerCanTransition = value;
        }
    }
}
