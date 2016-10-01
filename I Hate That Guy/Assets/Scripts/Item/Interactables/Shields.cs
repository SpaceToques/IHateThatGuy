using UnityEngine;
using System.Collections;
using System;

public class Shields : Interactable {
    protected override void InteractAction(GameObject interactor) {
        gameState.shieldsDown = true;
        interactable = false;
    }
}
