using UnityEngine;
using System.Collections;
using System;

public class Meter : Interactable {
    protected override void InteractAction(GameObject interactor) {
        base.Interact(interactor);

        if (interactor.GetComponent<Wrench>() != null) {
            gameState.meterBroken = true;
        }
    }
}
