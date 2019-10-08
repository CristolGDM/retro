using System;

public abstract class Item {
    public string name;
    public bool isUsable = false;
    public bool isEquippable = false;
    public bool needTarget = false;

    public abstract void OnUse();
}

public class Potion:Item {
    new public string name = "potion";
    new public bool isUsable = true;
    new public bool needTarget = true;

    public void OnUse(PlayerCharacter target) {
        Effects.HealTarget(target, 100);
    }

    public override void OnUse() {
        OnUse(GameData.getFirstPc());
    }
}

public class Poison:Item {
    new public string name = "poison";
    new public bool isUsable = true;
    new public bool needTarget = true;

    public void OnUse(PlayerCharacter target) {
        Effects.DamageTarget(target, 100);
    }

    public override void OnUse() {
        OnUse(GameData.getFirstPc());
    }
}