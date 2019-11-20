using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
