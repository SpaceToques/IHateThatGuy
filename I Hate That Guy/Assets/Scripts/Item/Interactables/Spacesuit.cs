using UnityEngine;
using System.Collections;
using System;

public class Spacesuit : Interactable {
    protected override void InteractAction(GameObject interactor) {
        if (interactor.GetComponent<Knife>() != null
            || interactor.GetComponent<Scissors>() != null) {
            gameState.suitPunctured = true;
            interactable = false;
        }
    }
}
