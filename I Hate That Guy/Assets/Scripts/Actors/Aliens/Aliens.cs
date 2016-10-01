using UnityEngine;
using System.Collections;

public class Aliens : GameStateListener {
    public override void aliensMad(bool aliensMad) {
        if (aliensMad) {
            Debug.Log("1000 Aliens cry out in anger!");

            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0);
        }
    }
}
