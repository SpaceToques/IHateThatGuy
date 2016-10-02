using UnityEngine;
using System.Collections;

public class Aliens : GameStateListener {

    public GameObject laserPrefab;
    public GameObject damageParticlesPrefab;
    private GameObject lasers;
    private GameObject damageParticles;

    public override void aliensMad(bool aliensMad) {
        if (aliensMad) {
            Debug.Log("1000 Aliens cry out in anger!");

            //instantiate the lasers as a child of the aliens
            lasers = Instantiate(laserPrefab, gameObject.transform.position, laserPrefab.transform.rotation) as GameObject;
            lasers.transform.SetParent(gameObject.transform);

            //instantiate the damage particles in front of the ship
            damageParticles = Instantiate(damageParticlesPrefab, damageParticlesPrefab.transform.position, damageParticlesPrefab.transform.rotation) as GameObject;
        }

        // make lasers visible if aliens are mad
        this.gameObject.GetComponent<SpriteRenderer>().enabled = aliensMad;

        // if shields are down, blow up the ship
        if (aliensMad && gameStateObject.shieldsDown) {
            gameStateObject.shipExploded = true;
        }
    }
}
