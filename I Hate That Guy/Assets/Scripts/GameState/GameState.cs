using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class GameState : Listenable<GameStateListener> {

    // start by notifiying all listeners of intial values.
    public override void Start() {
        base.Start();

        ForEachListener(listener => listener.fire(fire));
        Debug.Log("Game State: Fire is " + fire);
        ForEachListener(listener => listener.hullDamaged(hullDamaged));
        Debug.Log("Game State: Hull Damaged is " + hullDamaged);
        ForEachListener(listener => listener.aliensMad(aliensMad));
        Debug.Log("Game State: Aliens Mad is " + aliensMad);
        ForEachListener(listener => listener.meterBroken(meterBroken));
        Debug.Log("Game State: Meter Broken is " + meterBroken);
        ForEachListener(listener => listener.shieldsDown(shieldsDown));
        Debug.Log("Game State: Shields Down is " + shieldsDown);
    }

    public bool _fire;
    public bool fire
    {
        get { return _fire; }
        set {
            if (_fire != value) {
                _fire = value;
                ForEachListener(listener => listener.fire(value));
                Debug.Log("Game State: Fire is " + fire);
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
                Debug.Log("Game State: Hull Damaged is " + hullDamaged);
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
                Debug.Log("Game State: Aliens Mad is " + aliensMad);
            }
            updateShipExploded();
        }
    }

    public bool _meterBroken;
    public bool meterBroken { 
        get { return _meterBroken; }
        set {
            if (_meterBroken != value) {
                _meterBroken = value;
                ForEachListener(listener => listener.meterBroken(meterBroken));
                Debug.Log("Game State: Meter Broken is " + meterBroken);
            }
        }
    }

    public bool _shieldsDown;
    public bool shieldsDown {
        get { return _shieldsDown; }
        set {
            if (_shieldsDown != value) {
                _shieldsDown = value;
                ForEachListener(listener => listener.shieldsDown(shieldsDown));
                Debug.Log("Game State: Shields Down is " + shieldsDown);
            }

            updateShipExploded();
        }
    }

    public bool _shipExploded;
    public bool shipExploded {
        get { return _shipExploded; }
        set {
            if (_shipExploded != value) {
                _shipExploded = value;
                ForEachListener(listener => listener.shipExploded(shipExploded));
                Debug.Log("Game State: Ship Exploded is " + shipExploded);
            }
        }
    }

    private void updateShipExploded() {
        if (aliensMad && shieldsDown) {
            shipExploded = true;
        }
    }
}
