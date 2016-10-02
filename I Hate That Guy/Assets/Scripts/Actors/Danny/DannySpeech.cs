using UnityEngine;
using System.Collections;

public class DannySpeech : MonoBehaviour {

    // 0. create empty gameobject and attach this script
    // 1. create canvas and assign to script
    // 2. create text as child of canvas and assign to script
    // 3. assign danny to script

    public GameObject danny;
    public RectTransform text;
    public RectTransform canvas;

    private GameObject room;

    // Use this for initialization
    void Start () {
	}

    void Update()
    {
        Vector3 dannyScreenPoint = Camera.main.WorldToScreenPoint(danny.transform.position);
        Vector2 localPointOnCanvasRect;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, dannyScreenPoint, null, out localPointOnCanvasRect);
        localPointOnCanvasRect.x = localPointOnCanvasRect.x+330;
        localPointOnCanvasRect.y = localPointOnCanvasRect.y + 175;
        text.position = localPointOnCanvasRect;
    }
}
