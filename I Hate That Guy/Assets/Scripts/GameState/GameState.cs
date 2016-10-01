using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class GameState : Listenable<GameStateListener> {
    
    public GameObject[] listeners;

    public bool _fire;
    public bool fire
    {
        get { return _fire; }

        set
        {
            if (_fire != value)
            {
                _fire = value;
                ForEachListener(listener => listener.fire(value));
            }
        }
    }

    public bool _hullDamaged;
    public bool hullDamaged
    {
        get { return _hullDamaged; }

        set
        {
            if (_hullDamaged != value)
            {
                _hullDamaged = value;
                ForEachListener(listener => listener.hullDamaged(_hullDamaged));
            }
        }
    }

    public bool _aliensMad;
    public bool aliensMad
    {
        get { return _aliensMad; }

        set
        {
            if (_aliensMad != value)
            {
                _aliensMad = value;
                ForEachListener(listener => listener.hullDamaged(aliensMad));
            }
        }
    }

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
