using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStateNotifications : GameStateListener {
    private Text text;


	// Use this for initialization
	public override void Start () {
        base.Start();

        this.text = this.GetComponent<Text>();
        text.text = "";
	}

    public override void hullDamaged(bool hullDamaged) {
        if (hullDamaged) { text.text = "You damaged the hull!"; }
    }
    public override void fire(bool fire) {
        if (fire) { text.text = "You set a fire!"; }
    }

    public override void aliensMad(bool aliensMad) {
        if (aliensMad) { text.text = "You made some aliens quite angry!"; }
    }

    public override void meterBroken(bool meterBroken) {
        if (meterBroken) { text.text = "You broke a seemingly important piece of the engine!"; }
    }

    public override void shieldsDown(bool shieldsDown) {
        if (shieldsDown) { text.text = "You took down the shields!"; }
    }
    public override void shipExploded(bool shipExploded) {
        if (shipExploded) { text.text = "You blew up the ship!"; }
    }

    public override void suitPunctured(bool suitPunctured) {
        if (suitPunctured) { text.text = "You put a hole in the spacesuit!"; }
    }
}
