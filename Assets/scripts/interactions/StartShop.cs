using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartShop : EventTrigger {

    [SerializeField]
    private string dialog = "";
    [SerializeField]
    private StringIntDict AvailableItems;

    ///////////////////////////////////////

    public override IEnumerator StartInteraction() {
        yield return StartCoroutine(StartDialog());
    }

    private IEnumerator StartDialog() {
        DisablePlayerMovement();
        ShowDialogBackground();
        if (dialog.Length > 0) {
            yield return StartDialog(dialog);
        }
        yield return OpenShop(new Dictionary<string,int>(AvailableItems));
        HideDialogBackground();
        EnableMovingThis();
        EnablePlayerMovement();
    }
}
