using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Room : MonoBehaviour {

    public int x;
    public int y;

    public float offsetX;

	// Use this for initialization
	void Start () {
        Vector2 boxsize = gameObject.GetComponent<BoxCollider2D>().size;
        offsetX = boxsize.x / 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getX () {
        return this.x;
    }

    public int getY() {
        return this.y;
    }

    public float getOffset() {
        return this.offsetX;
    }
    
}
