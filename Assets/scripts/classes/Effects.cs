using System;

public class Effects {
    public static void DamageTarget(PlayerCharacter target, int amount) {
        target.currentPv = Math.Max(0, target.currentPv - amount);
    }

    public static void HealAll(int amount) {
        HealTarget(GameData.getFirstPc(), amount);
        HealTarget(GameData.getSecondPc(), amount);
        HealTarget(GameData.getThirdPc(), amount);
        HealTarget(GameData.getFourthPc(), amount);
    }

    public static void HealTarget(PlayerCharacter target, int amount) {
        if (target == null) return;

        target.currentPv = Math.Min(target.maxPv, target.currentPv + amount);
    }
}
