using UnityEngine;
using System.Collections;

public abstract class Interactable : Item {
    protected GameState gameState;

    public virtual void Start() {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    public virtual void Interact(GameObject interactor) {
        Debug.Log("Using " + interactor + " to interact with ");
    }
}
