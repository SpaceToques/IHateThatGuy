using UnityEngine;
using System.Collections;
using System;

public class Meter : Interactable {
    public override void Interact(GameObject interactor) {
        if (interactor.GetComponent<Wrench>() != null) {
            gameState.meterBroken = true;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
