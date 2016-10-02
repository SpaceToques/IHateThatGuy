using UnityEngine;
using System.Collections;
using System;

public abstract class GameStateListener : MonoBehaviour, Listener
{
    [SerializeField]
    public GameState gameStateObject;

    // Add self to listen to game state.
    public virtual void Start() {
        gameStateObject.AddListener(this);
    }

    public virtual void hullDamaged(bool hullDamaged) { }
    public virtual void fire(bool fire) { }
    public virtual void aliensMad(bool aliensMad) { }
    public virtual void meterBroken(bool meterBroken) { }
    public virtual void shieldsDown(bool shieldsDown) { }
}
