using UnityEngine;
using System.Collections;

public abstract class Interactable : Item {
    protected GameState gameState;

    public bool _interactable = true;
    public bool interactable {
        get { return _interactable; }
        protected set { _interactable = value; }
    }

    public virtual void Start() {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    public bool Interact(GameObject interactor) {
        if (interactable) {
            Debug.Log("Using " + interactor + " to interact with " + this.gameObject);
            InteractAction(interactor);
        }
        return interactable;
    }

    protected abstract void InteractAction(GameObject interactor);
}
