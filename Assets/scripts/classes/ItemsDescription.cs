using System;

public abstract class Item {
    public abstract string Name { get; }
    public abstract string Description { get; }
    public virtual bool IsUsable { get { return false; } }
    public virtual bool IsEquippable { get { return false; } }
    public virtual bool NeedTarget { get { return false; } }
    public virtual IEffect[] Effects { get { return null;}}
    public virtual PlayerCharacter[] Targets { get { return null; } }

    public virtual void OnUse() {
        if(Effects != null) {
            for(int i = 0; i < Effects.Length; i++) {
                Effects[i].Apply(Targets);
            }
        }
    }
}

public abstract class Consumable : Item {
    public override bool IsUsable { get { return true; } }
}
public abstract class SingleTargetConsumable : Consumable {
    public override bool NeedTarget { get { return true; } }
}

public class Potion : SingleTargetConsumable {
    public override string Name { get { return "Potion"; } }
    public override string Description { get { return "Restores 100HP to one character"; } }

    public override IEffect[] Effects {
        get {
            return new IEffect[] {
                new HealEffect(100)
            };
        }
    }
}

public class Poison : SingleTargetConsumable {
    public override string Name { get { return "Poison"; } }
    public override string Description { get { return "Deals 100HP damage to one character"; } }

    public override IEffect[] Effects {
        get {
            return new IEffect[] {
                new DamageEffect(100)
            };
        }
    }
}

public class HiPotion : SingleTargetConsumable {
    public override string Name { get { return "Hi-potion"; } }
    public override string Description { get { return "Restores 200HP to one character"; } }

    public override IEffect[] Effects {
        get {
            return new IEffect[] {
                new HealEffect(200)
            };
        }
    }
}

public class Elixir : Consumable {
    public override string Name { get { return "Elixir"; } }
    public override string Description { get { return "Restores 100HP to all characters"; } }

    public override IEffect[] Effects {
        get {
            return new IEffect[] {
                new HealEffect(100)
            };
        }
    }
}

public class FangOfDestroyer : Item {
    public override string Name { get { return "Fang of Grababos"; } }
    public override string Description { get { return "Fang of the Destroyer of Worlds, it shines with a malevolent aura"; } }
}