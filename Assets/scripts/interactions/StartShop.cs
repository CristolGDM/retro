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
        DisableMovingThis();
        TurnTowardPlayer();
        if (dialog.Length > 0) {
            ShowDialogBackground();
            yield return StartDialog(dialog);
            HideDialogBackgroundInstant();
        }
        yield return OpenShop(new Dictionary<string,int>(AvailableItems));
        EnablePlayerMovement();
        EnableMovingThis();
    }
}
