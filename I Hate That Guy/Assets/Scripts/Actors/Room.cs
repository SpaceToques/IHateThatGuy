﻿using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Room : MonoBehaviour {

    public int x;
    public int y;

	// Use this for initialization
	void Start () {
	
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
    
}
