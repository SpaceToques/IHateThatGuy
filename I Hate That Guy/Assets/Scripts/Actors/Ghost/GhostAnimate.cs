using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class GhostAnimate : MonoBehaviour {
    public Sprite[] sprites;
    private SpriteRenderer sprend;
    Sprite SpriteToRender;

	// Use this for initialization
	void Start () {
        sprend = gameObject.GetComponent<SpriteRenderer>();
        SpriteToRender = sprites[4];
	}
	
	// Update is called once per frame
	void Update () {

        
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
            {
                SpriteToRender = sprites[1];
            }
            if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
            {
                SpriteToRender = sprites[6];
            }
            if (Input.GetKeyUp("s") || Input.GetKeyUp("w") || Input.GetKeyUp("down") || Input.GetKeyUp("up"))
            {
                SpriteToRender = sprites[3];
            }
            if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
            {
                SpriteToRender = sprites[3];
            }
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
            {
                SpriteToRender = sprites[2];
            }
            if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
            {
                SpriteToRender = sprites[7];
            }
            if (Input.GetKeyUp("s") || Input.GetKeyUp("w") || Input.GetKeyUp("down") || Input.GetKeyUp("up"))
            {
                SpriteToRender = sprites[4];
            }
            if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
            {
                SpriteToRender = sprites[4];
            }
        }

        if (Input.GetKey("s") && !Input.GetKey("d") && !Input.GetKey("a") || Input.GetKey("down") && !Input.GetKey("right") && !Input.GetKey("left"))
        {
                SpriteToRender = sprites[0];
        }
         
        if (Input.GetKey("w") && !Input.GetKey("d") && !Input.GetKey("a") || Input.GetKey("up") && !Input.GetKey("right") && !Input.GetKey("left"))
        {
            SpriteToRender = sprites[5];
        }

        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
            {
                SpriteToRender = sprites[2];
            }

            if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
            {
                SpriteToRender = sprites[1];
            }
        }

        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
            {
                SpriteToRender = sprites[7];
            }

            if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
            {
                SpriteToRender = sprites[6];
            }
        }


        sprend.sprite = SpriteToRender;
    }
}
