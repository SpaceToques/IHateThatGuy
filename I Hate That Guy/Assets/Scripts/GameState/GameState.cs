using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class GameState : Listenable<GameStateListener> {

    public bool _fire;
    public bool fire
    {
        get { return _fire; }

        set {
            if (_fire != value) {
                _fire = value;
                ForEachListener(listener => listener.fire(value));
            }
        }
    }

    public bool _hullDamaged;
    public bool hullDamaged
    {
        get { return _hullDamaged; }

        set {
            if (_hullDamaged != value) {
                _hullDamaged = value;
                ForEachListener(listener => listener.hullDamaged(_hullDamaged));
            }
        }
    }

    public bool _aliensMad;
    public bool aliensMad
    {
        get { return _aliensMad; }
        set {
            if (_aliensMad != value) {
                _aliensMad = value;
                ForEachListener(listener => listener.aliensMad(aliensMad));
            }
        }
    }

    public bool _meterBroken;
    public bool meterBroken { 
        get { return _meterBroken; }
        set {
            if (_meterBroken) {
                _meterBroken = value;
                ForEachListener(listener => listener.meterBroken(meterBroken));
            }
        }
    }
}
