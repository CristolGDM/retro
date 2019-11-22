using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSceneMerchantDialog : EventTrigger {

    protected override List<EventAction> LoadActions() {
        List<EventAction> temp = new List<EventAction> {
            new StartDialog("Hello baby"),
            new StartDialog("How are you today?")
        };

        return temp;
    }
}
