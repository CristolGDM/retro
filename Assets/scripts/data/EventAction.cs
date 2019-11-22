using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventAction {

    public bool hasStarted;
    public bool hasFinished;

    public void Invoke() {
        hasStarted = true;

        DoMyStuff();
    }

    protected abstract void DoMyStuff();

    public virtual void Finish() {
        Debug.Log("finishing");
        hasFinished = true;
    }
}
