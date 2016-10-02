using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Room : MonoBehaviour {

    public int a, b;

    private float x;
    private float y;

    public float offsetX;

	// Use this for initialization
	void Start () {
        Vector2 boxsize = gameObject.GetComponent<BoxCollider2D>().size;
        offsetX = boxsize.x / 2;
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getA () {
        return this.a;
    }

    public int getB() {
        return this.b;
    }

    public float getX()
    {
        return this.x;
    }

    public float getY()
    {
        return this.y;
    }

    public float getOffset() {
        return this.offsetX;
    }
    
}
