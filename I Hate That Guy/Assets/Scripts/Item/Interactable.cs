using UnityEngine;
using System.Collections;

public abstract class Interactable : Item {
    protected GameState gameState = GameObject.Find("GameState").GetComponent<GameState>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public abstract void Interact(GameObject interactor);

}
