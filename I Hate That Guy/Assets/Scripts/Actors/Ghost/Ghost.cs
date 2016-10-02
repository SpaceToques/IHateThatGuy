using UnityEngine;
using System.Collections;
using System;

[Serializable]

// is kinematic
// item collider is trigger
// ctrl to drop item, space to pick up, space to use item on interactable
public class Ghost : Listenable<GhostListener> {

    public float speed = 15;
    private Pickupable item;
    private float x;
    private float y;
    public float maxHoldDist;
    private int a, b;

    public Sprite[] sprites;
    private SpriteRenderer sprend;
    Sprite SpriteToRender;

    private GameObject danny;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();

        item = null;
        sprend = gameObject.GetComponent<SpriteRenderer>();
        SpriteToRender = sprites[4];
        danny = GameObject.Find("Danny");
    }

	// Update is called once per frame
	public override void Update () {
        base.Update();
        // movement
        x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(x, y, 0);

        AnimateGhost(x, y);

        // drop item
        if (item != null)
        {
            float itemDist = Vector3.Distance(this.transform.position, item.transform.position);

            if (Input.GetButton("Fire1") || itemDist > maxHoldDist) {
                Debug.Log("Dropped " + item.gameObject);
                item.Drop();

                ForEachListener(listener => listener.GhostDropped(item.gameObject));

                item = null;
            }
        }
        int dannysA = danny.GetComponent<Danny>().getA();
        int dannysB = danny.GetComponent<Danny>().getB();
        if ((a== dannysA) && (b == dannysB) && (GetHeldItem() != null) ) // if in the same room as danny and holding somehting
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // pick up item
        if (Input.GetButton("Jump")
            && other.gameObject.GetComponent<Pickupable>() != null
            && item == null)
        {
            item = other.gameObject.GetComponent<Pickupable>();
            item.PickUp(this.gameObject);
            Debug.Log("Picked up " + item.gameObject);
            ForEachListener(listener => listener.GhostPickedUp(item.gameObject));
        }
        if (Input.GetButton("Jump")
                && other.gameObject.GetComponent<Interactable>() != null)
        {
            if (item != null) {
                other.GetComponent<Interactable>().Interact(item.gameObject);
            }
            other.GetComponent<Interactable>().Interact(this.gameObject);
        }

        if (other.gameObject.GetComponent<Room>() != null) {
            this.a = other.gameObject.GetComponent<Room>().getA();
            this.b = other.gameObject.GetComponent<Room>().getB();
            //Debug.Log("Player is in (" + this.a + ", " + this.b + ")");
        }

    }

    void AnimateGhost(float x, float y)
    {
        // Figures out the direction ghost is facing and animates accordingly
        if (x < 0 && y < 0)
        {
            SpriteToRender = sprites[1];
        }
        else if (x > 0 && y < 0)
        {
            SpriteToRender = sprites[2];
        }
        else if (x < 0 && y > 0)
        {
            SpriteToRender = sprites[6];
        }
        else if (x > 0 && y > 0)
        {
            SpriteToRender = sprites[7];
        }
        else if (x > 0)
        {
            SpriteToRender = sprites[4];
        }
        else if (x < 0)
        {
            SpriteToRender = sprites[3];
        }
        else if (y > 0)
        {
            SpriteToRender = sprites[5];
        }
        else if (y < 0)
        {
            SpriteToRender = sprites[0];

        }
        sprend.sprite = SpriteToRender;
    }

    public Pickupable GetHeldItem() {
        return item;
    }
}
