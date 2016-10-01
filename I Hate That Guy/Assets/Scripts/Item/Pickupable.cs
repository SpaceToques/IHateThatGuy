using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pickupable : Item {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PickUp(GameObject pickuper) {
        // pickup object by attaching to player
        this.gameObject.transform.SetParent(pickuper.gameObject.transform);

        // Remove certain physics for held objects
        this.gameObject.layer = LayerMask.NameToLayer("Held");
    }

    public void Drop() {
        // Readd  certain physics for no longer held items
        this.gameObject.layer = LayerMask.NameToLayer("Pickupable");
        this.gameObject.transform.parent = null;
    }
    
    //public abstract void InteractWith(GameObject i);

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
