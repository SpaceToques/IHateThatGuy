using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class GameState : Listenable<GameStateListener> {
    public bool hullDamaged;
    public bool fire;
    public bool aliensMad;

    [SerializeField]
    public GameObject[] listeners;

	// Use this for initialization
	public override void Start() {
        base.Start();
        hullDamaged = false;
        fire = false;
        aliensMad = false;

        foreach (GameObject listener in listeners)
        {
            GameStateListener listenerScript = listener.GetComponent<GameStateListener>();
            this.AddListener(listenerScript);
        }
	}
	
	// Update is called once per frame
	public override void Update () {
	
	}


}
