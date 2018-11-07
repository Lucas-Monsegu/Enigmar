using UnityEngine;
using System.Collections;

public class Telephone : MonoBehaviour {
    bool touched = false;
    Vector2 MainPoint;
    float OldAngle;
    // Use this for initialization
    void Start () {
        MainPoint = transform.position;
	}
	public  void OnClickTouched()
    {
        touched = true;
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetTouch(0).phase == TouchPhase.Began &&!touched)
        {
            MainPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            float OldAngle = transform.eulerAngles.z;
            /*float y = FPoint.y - MainPoint.y;
            float x = FPoint.x - MainPoint.x;

            float calc = Mathf.Rad2Deg * Mathf.Atan(y / x);
            if (x < 0)
                transform.eulerAngles = new Vector3(0, 0, calc + 180);
            else
                transform.eulerAngles = new Vector3(0, 0, calc);*/

        }
        else if(Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 FPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position); 
            float y = FPoint.y - MainPoint.y;
            float x = FPoint.x - MainPoint.x;
            float calc = Mathf.Rad2Deg* Mathf.Atan2(y,x);
            transform.eulerAngles = new Vector3(0, 0, calc);
            /*
            if (x < 0)
                transform.eulerAngles = new Vector3(0, 0, calc + 180);
            else
                transform.eulerAngles = new Vector3(0, 0, calc);*/
        }
        else if(touched)
        {
            float k = transform.eulerAngles.z - Time.deltaTime * 100;
            transform.eulerAngles = new Vector3(0, 0, k);
            if(transform.eulerAngles.z < 0)
            {
                transform.eulerAngles = Vector3.zero;
                touched = false;
            }
        }
    }
}
