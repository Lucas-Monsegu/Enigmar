using UnityEngine;
using System.Collections;

public class MovingItemFinger : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame

            transform.position = new Vector2(transform.position.x, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y);

        }
        
    }
}
