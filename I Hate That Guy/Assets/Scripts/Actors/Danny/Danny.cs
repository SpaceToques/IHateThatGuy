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
    private int x, y;
    private int x2, y2; // coordinates of next room he wants to visit.

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

    public int getX() {
        return this.x;
    }

    public int getY() {
        return this.y;
    }

    public void setX(int i) {
        this.x = i;
    }

    public void setY(int i) {
        this.y = i;
    }

    public int getNextX() {
        return this.x2;
    }

    public int getNextY() {
        return this.y2;
    }

    public void setNextLocation() {

    }
    
    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.GetComponent<Room>() != null) {
            this.x = other.gameObject.GetComponent<Room>().getX();
            this.y = other.gameObject.GetComponent<Room>().getY();
        }
    }
}
