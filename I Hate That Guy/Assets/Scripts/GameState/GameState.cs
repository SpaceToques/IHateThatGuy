using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class GameState : Listenable<GameStateListener> {
    public bool hullDamaged;
    public bool fire;
    public bool aliensMad;

	// Use this for initialization
	void Start () {
        hullDamaged = false;
        fire = false;
        aliensMad = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
