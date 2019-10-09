using System;

public abstract class Item {
    public virtual string Name { get { return "you shouldn't be able to see this, I messed up bad. Sorry."; } }
    public virtual bool IsUsable { get { return false; } }
    public virtual bool IsEquippable { get { return false; } }
    public virtual bool NeedTarget { get { return false; } }
    public virtual void OnUse() { }
}

public class Potion : Item {
    public override string Name { get { return "Potion"; } }
    public override bool IsUsable { get { return true; } }
    public override bool NeedTarget { get { return true; } }

    public void OnUse(PlayerCharacter target) {
        Effects.HealTarget(target, 100);
    }

    public override void OnUse() {
        OnUse(GameData.getFirstPc());
    }
}

public class Poison : Item {
    public override string Name { get { return "Poison"; } }
    public override bool IsUsable { get { return true; } }
    public override bool NeedTarget { get { return true; } }

    public void OnUse(PlayerCharacter target) {
        Effects.DamageTarget(target, 50);
    }

    public override void OnUse() {
        OnUse(GameData.getFirstPc());
    }
}

public class HiPotion : Item {
    public override string Name { get { return "Hi-potion"; } }
    public override bool IsUsable { get { return true; } }
    public override bool NeedTarget { get { return true; } }

    public void OnUse(PlayerCharacter target) {
        Effects.HealTarget(target, 200);
    }

    public override void OnUse() {
        OnUse(GameData.getFirstPc());
    }
}

public class Elixir : Item {
    public override string Name { get { return "Elixir"; } }
    public override bool IsUsable { get { return true; } }

    public void OnUse(PlayerCharacter target) {
        Effects.HealTarget(target, 100);
    }

    public override void OnUse() {
        OnUse(GameData.getFirstPc());
    }
}

public class FangOfDestroyer : Item {
    public override string Name { get { return "Fang of Grababos the Destroyer of Worlds"; } }
}