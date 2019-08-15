public class GameData {
    private static bool playerCanMove = true;

    public static bool PlayerCanMove {
        get {
            return playerCanMove;
        }
        set {
            playerCanMove = value;
        }
    }
}
