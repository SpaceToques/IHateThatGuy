using UnityEngine;
using System.Collections;
using System;

public class Wires : Interactable {
    protected override void InteractAction(GameObject interactor) {
        if (interactor.GetComponent<Knife>() != null
            || interactor.GetComponent<Scissors>() != null) {
            gameState.wiresCut = true;
            interactable = false;
        }
    }
}
