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
    private int a, b;
    private int a2, b2; // coordinates of next room he wants to visit.

    public float speed = 1.5f;
    private float x, y; // absolute point
    private int vx, vy; // velocities
    public float dannysOffset; // to help with moving adequate amount
    public float roomX;
    public float roomOffset;

    private float startOfMovingSlightly;
    private float moveToX;

    // Use this for initialization
    void Start () {
        WalkTo(0, 0);
        dannysOffset = gameObject.GetComponent<BoxCollider2D>().size.x / 2;
    }
	
	// Update is called once per frame
	void Update () {
        x = vx * speed * Time.deltaTime;
        y = vy * speed * Time.deltaTime;
        transform.Translate(x, y, 0);
        WalkTo(0, 0);
    }

    void WalkTo (int a2, int b2) {
        // Begin trek to a new room on the grid
        if (this.b != b2) {
            if (((a==2) && (b==0)) || ((a==2) && (b==1)) || ((a==4) && (b==2))) { // if on a ladder "room"
                Climb(b2 - this.b);
            } else {
                MoveToLadderFrom(this.a, this.b);
            }
        }
        // move left/right
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
        vy = i/Mathf.Abs(i); // get either 1 or -1 for speed

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
        if (other.gameObject.GetComponent<Room>() != null) {
            this.a = other.gameObject.GetComponent<Room>().getA();
            this.b = other.gameObject.GetComponent<Room>().getB();
            this.roomX = other.gameObject.GetComponent<Room>().getX();
            this.roomOffset = other.gameObject.GetComponent<Room>().getOffset();
            Debug.Log("Danny is in (" + this.a + ", " + this.b + ")");
        }
    }
}
