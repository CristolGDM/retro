using System;

public abstract class Item {
    public abstract string Name { get; }
    public abstract string Description { get; }
    public virtual bool IsUsable { get { return false; } }
    public virtual bool IsEquippable { get { return false; } }
    public virtual bool NeedTarget { get { return false; } }
    public virtual bool IsConsumable { get { return false; } }
    public virtual IEffect[] Effects { get { return null;}}
    public PlayerCharacter[] Targets;

    public virtual void OnUse() {
        if(Effects != null) {
            PlayerCharacter[] currentTargets = null;
            if(Targets == null) {
                if (NeedTarget) {
                    currentTargets = new PlayerCharacter[] { GameData.GetFirstPc() };
                }
                else {
                    currentTargets = GameData.GetParty();
                }
            }
            else {
                currentTargets = Targets;
            }

            for(int i = 0; i < Effects.Length; i++) {
                Effects[i].Apply(currentTargets);
            }

            if (IsConsumable) {
                Inventory.RemoveItemFromInventory(this, 1);
            }
        }
    }

    public void SetTargets(PlayerCharacter[] itemTargets) {
        Targets = itemTargets;
    }
}

public abstract class Consumable : Item {
    public override bool IsUsable { get { return true; } }
    public override bool IsConsumable { get { return true; } }
}
public abstract class SingleTargetConsumable : Consumable {
    public override bool NeedTarget { get { return true; } }
}