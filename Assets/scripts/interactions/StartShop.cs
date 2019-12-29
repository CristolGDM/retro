using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartShop : EventTrigger {

    [SerializeField]
    private string dialog = "";
    [SerializeField]
    private List<string> AvailableItems = new List<string>();

    ///////////////////////////////////////

    public override IEnumerator StartInteraction() {
        yield return StartCoroutine(StartDialog());
    }

    private IEnumerator StartDialog() {
        DisablePlayerMovement();
        DisableMovingThis();
        TurnTowardPlayer();
        if (dialog.Length > 0) {
            ShowDialogBackground();
            yield return StartDialog(dialog);
            HideDialogBackgroundInstant();
        }
        yield return OpenShop(AvailableItems);
        EnablePlayerMovement();
        EnableMovingThis();
    }
}
