using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DannySpeech : MonoBehaviour
{

    // 0. create empty gameobject and attach this script
    // 1. create canvas and assign to script
    // 2. create text as child of canvas and assign to script
    // 3. assign danny to script

    public GameObject danny;
    public RectTransform text;
    public RectTransform canvas;
    private int a;
    private int b;

    // Use this for initialization
    void Start()
    {
    }

    void Update()
    {
        Vector3 dannyScreenPoint = Camera.main.WorldToScreenPoint(danny.transform.position);
        Vector2 localPointOnCanvasRect;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, dannyScreenPoint, null, out localPointOnCanvasRect);
        localPointOnCanvasRect.x = localPointOnCanvasRect.x + 330;
        localPointOnCanvasRect.y = localPointOnCanvasRect.y + 175;
        text.position = localPointOnCanvasRect;

        a = danny.GetComponent<Danny>().getA();
        b = danny.GetComponent<Danny>().getB();

        switch (b)
        {
            case 0:
                if (a == 1)
                {
                    text.gameObject.GetComponent<Text>().text = "By killing that guy I have ensured my survival";
                }
                else
                {
                    if (a == 3)
                    {
                        text.gameObject.GetComponent<Text>().text = "Ghosts aren't real, right?";
                    }
                    else
                    {
                        text.gameObject.GetComponent<Text>().text = "";
                    }
                }
                break;
            case 1:
                if (a == 3)
                {
                    text.gameObject.GetComponent<Text>().text = "How do you fly this thing? Shouldn't have killed that guy";
                }
                else
                {
                    text.gameObject.GetComponent<Text>().text = "";
                }
                break;
            case 2:
                if (a == 0 || a == 1)
                {
                    text.gameObject.GetComponent<Text>().text = "When I get home I will murder more people";
                }
                else
                {
                    if (a == 3)
                    {
                        text.gameObject.GetComponent<Text>().text = "I'm scared of ghosts";
                    }
                    else
                    {
                        text.gameObject.GetComponent<Text>().text = "";
                    }
                }
                break;
            default:
                text.gameObject.GetComponent<Text>().text = "";
                break;
        }
    }
}