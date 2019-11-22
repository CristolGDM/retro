using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Event {

    public List<EventAction> actions = new List<EventAction>();

    public void Update() {
        //if (!actions.Any()) return;
        //Debug.Log(actions[0].hasFinished);

        //if (actions[0].hasFinished) {
        //    Debug.Log("action0 has finished");
        //    actions.Remove(actions[0]);
        //    if (actions.Any()) {
        //        actions[0].Invoke();
        //    }
        //}
    }

    public void BeginEvent() {
        if (!actions.Any()) return;

        foreach(EventAction action in actions) {
            action.Invoke();
        }
    }

    public Event(List<EventAction> newActions){
        actions = newActions;
    }
}
