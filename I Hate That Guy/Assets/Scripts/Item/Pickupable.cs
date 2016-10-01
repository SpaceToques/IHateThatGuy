using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Pickupable : Item {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // make this abstract later
    public void InteractWith(GameObject i) { }
}
