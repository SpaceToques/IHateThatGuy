using UnityEngine;
using System.Collections;
using System;

public class Radio : Interactable {
    protected override void InteractAction(GameObject interactor) {
        base.Interact(interactor);

        if (interactor.GetComponent<Ghost>() != null) {
            gameState.aliensMad = true;
            this.interactable = false;
        }
    }
}
