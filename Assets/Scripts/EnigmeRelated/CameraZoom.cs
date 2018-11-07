using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraZoom : MonoBehaviour
{
    public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
    public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.
    public float speed = 1;
    [SerializeField]
    RectTransform bg;
    // Use this for initialization
    void Start()
    {

    }


    void Update()
    {
        // If there are two touches on the device...

        if (Input.touchCount == 1)
        {
            Touch t1 = Input.GetTouch(0);
            bg.offsetMax += t1.deltaPosition*speed;
            bg.offsetMin += t1.deltaPosition * speed;
            if(Mathf.Abs(bg.offsetMax.x)>1080*bg.localScale.x/4)
            {
                Vector2 k = new Vector2(1080 * bg.localScale.x / 4, bg.offsetMax.y);
                bg.offsetMax = k;
                bg.offsetMin = k;
            }
            if(Mathf.Abs(bg.offsetMax.y)>1920*bg.localScale.y/4)
            {
                Vector2 k = new Vector2(bg.offsetMax.x, 1920 * bg.localScale.y / 4);
                bg.offsetMin = k;
                bg.offsetMax = k;
            }
        }

        else if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // If the camera is orthographic...
            if (bg.localScale.x<5)
            {
                // ... change the orthographic size based on the change in distance between the touches.
                float k = bg.localScale.x+ (deltaMagnitudeDiff * orthoZoomSpeed);
                bg.localScale = new Vector3(k, k, 0);
                // Make sure the orthographic size never drops below zero.
            }
        }
    }
}
