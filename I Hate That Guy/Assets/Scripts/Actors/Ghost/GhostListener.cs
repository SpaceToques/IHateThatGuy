using UnityEngine;
using System.Collections;

public class GhostListener : MonoBehaviour, Listener {
    [SerializeField]
    public Ghost ghost;

    public virtual void Start() {
        ghost.AddListener(this);
    }

    public virtual void GhostPickedUp(GameObject item) { }
    public virtual void GhostDropped(GameObject item) { }
}
