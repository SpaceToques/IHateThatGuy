using UnityEngine;
using System.Collections;

// is kinematic
// item collider is trigger
// ctrl to drop item, space to pick up, alt to use item on interactable
public class Ghost : MonoBehaviour {

    public float speed = 15;
    private GameObject item;
    private float x;
    private float y;

	// Use this for initialization
	void Start ()
    {
        item = null;
    }

	// Update is called once per frame
	void Update () {
        // movement
        x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(x, y, 0);

        // drop item
        if (item != null && Input.GetButton("Fire1"))
        {
            item.transform.parent = null;
            item = null;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // pick up item
        if (Input.GetButton("Jump")
            && other.gameObject.GetComponent<Pickupable>() != null
            && item == null)
        {
            item = other.gameObject;
            item.transform.SetParent(gameObject.transform);
        }
        else
        {
            // use item
            if (Input.GetButton("Fire2")
                && other.gameObject.GetComponent<Interactable>() != null
                && item != null)
            {
                item.GetComponent<Pickupable>().InteractWith(other.gameObject);
            }
        }
    }
}
