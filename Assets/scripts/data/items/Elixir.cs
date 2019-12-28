using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elixir : Consumable {
    public override string Name { get { return "Elixir"; } }
    public override string Description { get { return "Restores 100HP to all characters"; } }
    public override int Cost { get { return 1000; } }

    public override IEffect[] Effects {
        get {
            return new IEffect[] {
                new HealEffect(100)
            };
        }
    }
}
