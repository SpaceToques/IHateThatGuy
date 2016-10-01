using UnityEngine;
using System.Collections;
using System;

public class Radio : Interactable {
    public override void Interact(GameObject interactor) {
        base.Interact(interactor);

        if (interactor.GetComponent<Ghost>() != null) {
            gameState.aliensMad = true;
        }
    }
}
