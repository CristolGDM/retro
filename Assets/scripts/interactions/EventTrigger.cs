using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class EventTrigger : OnInteract {

    protected List<EventAction> actions;

    protected abstract List<EventAction> LoadActions();

    public override void StartInteraction() {
        actions = LoadActions();

        if (actions.Any()) {
            Event newEvent = new Event(actions);
            newEvent.BeginEvent();
        }

        GameData.PlayerCanMove = true;
    }
}
