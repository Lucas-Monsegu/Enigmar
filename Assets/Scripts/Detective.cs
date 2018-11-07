using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Detective : MonoBehaviour {
    bool b1;
    bool b2;
    [SerializeField]
    Transform b1tran;
    [SerializeField]
    Transform b2tran;
    [SerializeField]
    RectTransform b1rect;
    [SerializeField]
    RectTransform b2rect;

	// Use this for initialization
	void Start () {
        b1 = false;
        b2 = false;
	}
    public void OnClick(bool e)
    {
        if (e)
            b1 = true;
        else
            b2 = true;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            // Get movement of the finger since last frame
            Vector2 k = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            if (b1)
            {
                b1tran.position = new Vector2(k.x, b1tran.position.y);
            }
            else if (b2)
            {
                b2tran.position = new Vector2(b2tran.position.x, k.y);
                if (b2rect.offsetMax.y > 0)
                {
                    b2rect.offsetMin = new Vector2(-18, 0);
                    b2rect.offsetMax = new Vector2(-18, 10);
                }
            }
            
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                b1 = b2 = false;
            }
        }
        if(Input.GetMouseButton(0))
        {
            Vector2 k = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (b1)
            {
                b1tran.position = new Vector2(k.x, b1tran.position.y);
            }
            else if (b2)
            {
                b2tran.position = new Vector2(b2tran.position.x, k.y);
                if (b2rect.offsetMax.y > 0)
                {
                    b2rect.offsetMin = new Vector2(-18, 0);
                    b2rect.offsetMax = new Vector2(-18, 10);
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            b1 = b2 = false;
        }
    }
}
