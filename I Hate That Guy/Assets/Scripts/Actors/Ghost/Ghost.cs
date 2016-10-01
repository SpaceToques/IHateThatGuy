using UnityEngine;
using System.Collections;

// is kinematic
// item collider is trigger
// ctrl to drop item, space to pick up, alt to use item on interactable
public class Ghost : MonoBehaviour {

    public float speed = 15;
    private Pickupable item;
    private float x;
    private float y;
    public float maxHoldDist;

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
        if (item != null)
        {
            float itemDist = Vector3.Distance(this.transform.position, item.transform.position);

            if (Input.GetButton("Fire1") || itemDist > maxHoldDist) {
                Debug.Log("Dropped " + item.gameObject);
                item.Drop();

                item = null;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other);
        // pick up item
        if (Input.GetButton("Jump")
            && other.gameObject.GetComponent<Pickupable>() != null
            && item == null)
        {
            item = other.gameObject.GetComponent<Pickupable>();
            item.PickUp(this.gameObject);
            Debug.Log("Picked up " + item.gameObject);
        }
        if (Input.GetButton("Fire2")
                && other.gameObject.GetComponent<Interactable>() != null
                && item != null)
        {
            if (item != null) {
                other.GetComponent<Interactable>().Interact(item.gameObject);
            }
            other.GetComponent<Interactable>().Interact(this.gameObject);
        }
        
    }
}
