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
    
    public abstract void InteractWith(GameObject i);

    // example implementation
    /*
    public override void InteractWith(GameObject i)
    {
        if (!(i.GetComponent<Interactable>() is 'X'))
        {
            return;
        }
        else
        {
            // do something that affects game state
        }
    }
    */
}
