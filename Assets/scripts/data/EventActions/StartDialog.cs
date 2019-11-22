using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog : EventAction {
    string dialog;

    protected override void DoMyStuff() {
        Debug.Log(dialog);
        Finish();
    }

    public StartDialog(string text) {
        dialog = text;
    }
}
