using UnityEngine;
using System.Collections;
using System;

public class Meter : Interactable {
    public override void Interact(GameObject interactor) {
        base.Interact(interactor);

        if (interactor.GetComponent<Wrench>() != null) {
            gameState.meterBroken = true;
        }
    }
}
