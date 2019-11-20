using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
