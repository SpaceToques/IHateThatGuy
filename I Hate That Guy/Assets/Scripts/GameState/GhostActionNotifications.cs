using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GhostActionNotifications : GhostListener {
    private Text text;

    // Use this for initialization
    public override void Start() {
        base.Start();

        this.text = GetComponent<Text>();
        text.text = "";
    }

    public override void GhostPickedUp(GameObject item) {
        this.text.text = "You picked up a " + item.name;
    }
    public override void GhostDropped(GameObject item) {
        this.text.text = "You dropped the " + item.name;
    }
}
