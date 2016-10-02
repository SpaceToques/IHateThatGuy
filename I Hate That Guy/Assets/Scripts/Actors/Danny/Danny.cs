using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Danny : MonoBehaviour {
    // Danny is the guy who kills you at the beginning of the game, and is your target for the duration of the game
    // Danny cycles his movement among the rooms of the spaceship. Each room is considered a grid target. Naturally,
    // he can only move left to right / right to left on floors, but can move up or down a ladder. Each ladder is given its own
    // 'room' segment, so we know the room he can move up in.
    // Ladder coords: [0,4], [1,2], [2,2]

    // grid coordinates of Danny
    private int a, b;
    private int a2, b2; // coordinates of next room he wants to visit.

    public float speed = 1.5f;
    private float x, y; // absolute point
    private int vx, vy; // velocities
    public float dannysOffset; // to help with moving adequate amount
    public float roomX;
    public float roomY;
    public float roomOffset;

    private GameObject currentRoom;
    private bool movingToCenterXOfRoom = false;
    private bool movingToCenterYOfRoom = false;

    private float startOfMovingSlightly;
    private float moveToX;

    // Use this for initialization
    void Start () {
        WalkTo(0, 0);
        dannysOffset = gameObject.GetComponent<BoxCollider2D>().size.x / 2;
        x = transform.position.x;
        y = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        WalkTo(0, 0);

        if (movingToCenterXOfRoom) {
            //Debug.Log("Moving to center of room (" + a + "," + b + ")");
            // move immediately if we can
            if (speed * Time.deltaTime > Math.Abs(roomX - x)) {
                x = roomX;
                movingToCenterXOfRoom = false;
                //Debug.Log("Arrived at center of room (" + a + "," + b + ")");
            } else {
                x = x + Math.Sign(roomX - x) * speed * Time.deltaTime;
            }

            //Debug.Log("Danny has x = " + x + " Room has x = " + roomX);
            //Debug.Log("Danny's speed = " + speed + " deltatime = " + Time.deltaTime);
        } else if (movingToCenterYOfRoom) {
            if (speed * Time.deltaTime > Math.Abs(roomY - y)) {
                y = roomY;
                movingToCenterYOfRoom = false;
                //Debug.Log("Arrived at center of room (" + a + "," + b + ")");
            } else {
                y = y + Math.Sign(roomY - y) * speed * Time.deltaTime;
            }
        } else {
            x = x + vx * speed * Time.deltaTime;
            y = y + vy * speed * Time.deltaTime;
        }

        transform.position = new Vector2(x, y);
    }

    void WalkTo (int a2, int b2) {
        // Begin trek to a new room on the grid
        if (this.b != b2) {
            //Debug.Log("here0");
            if (IsLadder(a, b)) { // if on a ladder "room"
                Climb(b2 - this.b);
            } else {
                MoveToLadderFrom(this.a, this.b);
            }
        } else {
            // move left/right
            MoveToSameFloor(a2);
        }
    }

    private void MoveToSameFloor(int a2) {
        if (a > a2) {
            vx = -1;
            vy = 0;
        } else if (a < a2 ) {
            vx = 1;
            vy = 0;
        } else {
            vx = 0;
            vy = 0;
        }
    }

    // move to the ladder based on initial position
    void MoveToLadderFrom(int a, int b) {
        if (b != 2) { // if not the top floor
            if (a < 3) { // to the left of the ladder
                vx = 1;
                vy = 0;
            } else if (a > 3) { // to the right of the ladder
                vx = -1;
                vy = 0;
            } else { // at the ladder
                if (x < roomX+roomOffset) {
                    vx = 1;
                }
                else if (x > roomX+roomOffset) {
                    vx = -1;
                }
                else {
                    vx = 0;
                    vy = 0;
                }
            }
        } else {
            // just move right
            if (a == 4) { // at ladder room
                if (x < roomX+roomOffset) {
                    vx = 1;
                }
                else if (x > roomX+roomOffset) {
                    vx = -1;
                }
                else {
                    vx = 0;
                    vy = 0;
                }
            } else {
                vx = 1;
                vy = 0;
            }
        }
    }

    void Climb (int i) {
        // if i is positive, climb up
        // if i is negative, climb down
        vx = 0;
        vy = Math.Sign(i); // get either 1 or -1 for speed

        //Debug.Log("Climbing with vx = " + vx + " vy = " + vy);
    }

    public int getA() {
        return this.a;
    }

    public int getB() {
        return this.b;
    }

    public void setA(int i) {
        this.a = i;
    }

    public void setB(int i) {
        this.b = i;
    }

    public int getNextA() {
        return this.a2;
    }

    public int getNextB() {
        return this.b2;
    }

    public void setNextLocation() {

    }
    
    void OnTriggerStay2D(Collider2D other) {
        /*
        if (other.gameObject.GetComponent<Room>() != null) {
            this.a = other.gameObject.GetComponent<Room>().getA();
            this.b = other.gameObject.GetComponent<Room>().getB();
            this.roomX = other.gameObject.GetComponent<Room>().getX();
            this.roomOffset = other.gameObject.GetComponent<Room>().getOffset();
            this.currentRoom = other.gameObject;
            Debug.Log("Danny is in (" + this.a + ", " + this.b + ")");
        }
        */
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Room>() != null)
        {
            this.a = other.gameObject.GetComponent<Room>().getA();
            this.b = other.gameObject.GetComponent<Room>().getB();
            this.roomX = other.gameObject.GetComponent<Room>().getX();
            this.roomY = other.gameObject.GetComponent<Room>().getY();
            this.roomOffset = other.gameObject.GetComponent<Room>().getOffset();
            this.currentRoom = other.gameObject;

            this.movingToCenterXOfRoom = true;
            if (IsLadder(a, b)) { this.movingToCenterYOfRoom = true; Debug.Log("Moving to center Y "); }

            Debug.Log("Danny is in (" + this.a + ", " + this.b + ")");
            Debug.Log("Room has x = " + roomX);
            Debug.Log("Room has y = " + roomY);
        }
    }

    private bool IsLadder(int a, int b) {
        return ((a == 2) && (b == 0)) || ((a == 2) && (b == 1)) || ((a == 4) && (b == 2));
    }
}
