using UnityEngine;
using System.Collections;
using System;

public interface GameStateListener : Listener
{
    void hullDamaged(bool hullDamaged);
    void fire(bool fire);
    void aliensMad(bool aliensMad);
}
