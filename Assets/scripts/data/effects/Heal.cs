using System;
using UnityEngine;

public class HealEffect : IEffect {
    private int amount;

    public void Apply(PlayerCharacter[] targets) {
        foreach (PlayerCharacter target in targets) {
            target.currentPv = Math.Min(target.maxPv, target.currentPv + amount);
        }
    }

    public HealEffect(int amount) {
        this.amount = amount;
    }
}