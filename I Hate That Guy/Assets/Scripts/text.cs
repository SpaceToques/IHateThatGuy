using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class text : MonoBehaviour {

    Text info;

	// Use this for initialization
	void Start () {
        info = GetComponent<Text>();
        info.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void alienVoice()
    {
        info.text = "Spooky Voice over the Radio: Hello Humans. We are going to destroy you now.";

    }

    public void shipExplode()
    {
        info.text = "GG EZ";
    }
}
