using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manivelle : MonoBehaviour {
    bool Got;
    Vector2 MainPoint;
    [SerializeField]
    RawImage Rope;
    [SerializeField]
    RawImage Flag;


    float endp;
    bool stop;
    float flagpos;
    float flagposx;
    int counter;
    float lastframe;
    float drapspeed;

	// Use this for initialization
	void Start () {
        MainPoint  =(transform.position);
        Got = false;
        stop = true;
        flagpos = Flag.transform.position.y;
        flagposx = Flag.transform.position.x;
        endp = 6;
	}
    public void OnIt()
    {
        Got = true;

    }
    public void NotOnIt()
    {
        Got = false;

    }
    // Update is called once per frame
    void Update()
    {
        //print((transform.position));
        /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 FPoint = new Vector2(transform.position.x, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y);
            if(Got)
            {
                float y = FPoint.y - MainPoint.y;
                float x = FPoint.x - MainPoint.x;
                transform.eulerAngles = new Vector2(0, Mathf.Rad2Deg * Mathf.Sin(y / x));
            }
        }*/
   
        if (Input.touchCount>0&&Got)
        {
            print("hmm");
            //Vector2 FPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 FPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            float y = FPoint.y -MainPoint.y;
            float x = FPoint.x -MainPoint.x;
            float calc = Mathf.Rad2Deg * Mathf.Atan(y / x);
            if (x<0)
                transform.eulerAngles = new Vector3(0,0, calc + 180);
            else
                transform.eulerAngles = new Vector3(0, 0, calc);

            print(Mathf.Abs(lastframe) - Mathf.Abs(transform.eulerAngles.z));
            if (Mathf.Abs(lastframe) - Mathf.Abs(transform.eulerAngles.z) > 20)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if (lastframe > 320 && transform.eulerAngles.z < 50)
            {
                counter += 1;
            }

            else if (lastframe < 50 && transform.eulerAngles.z > 320)
            {
                print("mdr");
                counter -= 1;
                if(counter<0)
                {
                    counter = 0;
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
            if (counter == 4 && transform.eulerAngles.z > 180)
            {
                transform.eulerAngles = new Vector3(0, 0, 180);
            }
            
        }
        else if (Input.GetMouseButton(0))
        {
           
                print("what");
                //Vector2 FPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 FPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float y = FPoint.y - MainPoint.y;
                float x = FPoint.x - MainPoint.x;
                float calc = Mathf.Rad2Deg * Mathf.Atan(y / x);
                if (x < 0)
                    transform.eulerAngles = new Vector3(0, 0, calc + 180);
                else
                    transform.eulerAngles = new Vector3(0, 0, calc);


            print(Mathf.Abs(lastframe) - Mathf.Abs(transform.eulerAngles.z));

            if (lastframe > 320 && transform.eulerAngles.z < 50)
                {
                    counter += 1;
                }

                else if (lastframe < 50 && transform.eulerAngles.z > 320)
                {
                    counter -= 1;
                    if (counter < 0)
                    {
                        counter = 0;
                        transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                }
                if (counter == 4 && transform.eulerAngles.z > 180)
                {
                    transform.eulerAngles = new Vector3(0, 0, 180);
                }

            
        }
        else
        {
            print("zz");
            float k = transform.eulerAngles.z - Time.deltaTime * 40;

            if (lastframe < 50 && k > 320 || k<0)
            {
                if (counter == 0)
                    transform.eulerAngles = Vector3.zero;
                else
                {
                    counter -= 1;
                    transform.eulerAngles = new Vector3(0, 0, k);
                    
                }
                
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0,k);
                
            }

        }
        Rope.uvRect = new Rect(0, transform.eulerAngles.z / 400, 1, 1);

        if (counter == 4)
        {
            Flag.transform.position = new Vector2(flagposx, Mathf.Lerp(flagpos, endp, transform.eulerAngles.z / 300));
        }
        lastframe = transform.eulerAngles.z;


    }
}
