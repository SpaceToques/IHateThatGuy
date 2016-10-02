using UnityEngine;
using System.Collections;

public class Aliens : GameStateListener {
    public override void aliensMad(bool aliensMad) {
        if (aliensMad) {
            Debug.Log("1000 Aliens cry out in anger!");
        }

        // make lasers visible if aliens are mad
        this.gameObject.GetComponent<SpriteRenderer>().enabled = aliensMad;

        // if shields are down, blow up the ship
        if (aliensMad && gameStateObject.shieldsDown) {
            // TODO
        }
    }
}
