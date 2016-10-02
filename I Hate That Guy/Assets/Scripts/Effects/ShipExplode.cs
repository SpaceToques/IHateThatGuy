using UnityEngine;
using System.Collections;

public class ShipExplode : GameStateListener {
    public Object explosion;

	// Use this for initialization
	public override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
	}

    // When we explode, do stuff
    public override void shipExploded(bool shipExploded) {
        if (shipExploded) {
            Instantiate(explosion, this.transform);
        }
    }
}
