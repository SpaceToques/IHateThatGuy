﻿using UnityEngine;
using System.Collections;
using System;

public class Shields : Interactable {
    protected override void InteractAction(GameObject interactor) {
        if (interactor.GetComponent<Ghost>() != null) {
            gameState.shieldsDown = true;
            interactable = false;
        }
    }
}
