using System;

public interface IEffect {

    void Apply(PlayerCharacter[] targets);
}

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
