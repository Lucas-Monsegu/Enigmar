using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemFingerAll : MonoBehaviour {
    RawImage im;
    // Use this for initialization
    void Start () {
         im = GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            // Get movement of the finger since last frame
            im.enabled = true;
            Vector2 k = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            transform.position = new Vector2( k.x,k.y+3);
        }
        else if (Input.GetMouseButton(0))
        {
            im.enabled = true;
            Vector2 k =Camera.main.ScreenToWorldPoint (Input.mousePosition);
            transform.position = new Vector2(k.x, k.y+3);
        }
        else
            im.enabled = false;
    }
}
