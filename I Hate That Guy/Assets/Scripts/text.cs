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
        info.text = "Spooky Voice: We ArE cOmInG foR yUoOOoOOoO";
    }

    public void shipExplode()
    {
        info.text = "GG EZ";
        Debug.Log("GGEX");
    }
}
