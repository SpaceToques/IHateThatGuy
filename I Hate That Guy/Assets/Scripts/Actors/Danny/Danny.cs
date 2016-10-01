using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Danny : MonoBehaviour {
    // Danny is the guy who kills you at the beginning of the game, and is your target for the duration of the game
    // Danny cycles his movement among the rooms of the spaceship. Each room is considered a grid target. Naturally,
    // he can only move left to right / right to left on floors, but can move up or down a ladder. Each ladder is given its own
    // 'room' segment, so we know the room he can move up in.
    // Ladder coords: [0,4], [1,2], [2,2]

    // grid coordinates of Danny
    List<int> location = new List<int>();
    List<int> nextLocation = new List<int>(); // coordinates of next room he wants to visit.

	// Use this for initialization
	void Start () {
	    // Figure out where to start

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Walk () {

    }

    void Climb () {

    }

    public List<int> getLocation() {
        return this.location;
    }

    public void setLocation(int x, int y) {
        this.location.Clear();
        this.location.Add(x);
        this.location.Add(y);
    }

    public List<int> getNextLocation() {
        return this.nextLocation;
    }

    public void setNextLocation(int x, int y) {
        this.nextLocation.Clear();
        this.nextLocation.Add(x);
        this.nextLocation.Add(y);
    }
}
