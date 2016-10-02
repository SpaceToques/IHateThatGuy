using UnityEngine;
using System.Collections;
using System;

public class Engine : Interactable {
    protected override void InteractAction(GameObject interactor) {
        if (interactor.GetComponent<Wrench>() != null) {
            gameState.meterBroken = true;
            interactable = false;
        }
    }
}
