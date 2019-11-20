using System;
using UnityEngine;

public class DamageEffect : IEffect {
    private int amount;

    public void Apply(PlayerCharacter[] targets) {
        foreach (PlayerCharacter target in targets) {
            target.currentPv = Math.Max(0, target.currentPv - amount);
        }
    }

    public DamageEffect(int amount) {
        this.amount = amount;
    }
}
