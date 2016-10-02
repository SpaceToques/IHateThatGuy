using UnityEngine;
using System.Collections;

public class Shields : GameStateListener {
    public override void shieldsDown(bool shieldsDown) {
        // hide or show based on shield status
        this.gameObject.GetComponent<SpriteRenderer>().enabled = !shieldsDown;
    }
}
