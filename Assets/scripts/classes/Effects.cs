using System;

public class Effects {
    public static void DamageTarget(PlayerCharacter target, int amount) {
        target.currentPv = Math.Max(0, target.currentPv - amount);
    }
    public static void HealTarget(PlayerCharacter target, int amount) {
        target.currentPv = Math.Min(target.maxPv, target.currentPv + amount);
    }
}
