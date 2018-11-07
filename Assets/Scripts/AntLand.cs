using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AntLand : MonoBehaviour {
    bool[,] tab;
    Fourmi four;
    DeviceOrientation Dev;
    bool stop;
    int[] lastP;
    [SerializeField]
    RectTransform myTran;
    MainMenu MM;
    bool right;
    // Use this for initialization
    struct Fourmi
    {
        public int x;
        public int y;
        public int ori;
        public bool right;
        public void Set(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        public void Next()
        {
            if (right)
            {
                if (ori == 0)
                {
                    Set(x + 1, y);
                }
                else if (ori == 1)
                    Set(x, y + 1);
                else if (ori == 2)
                    Set(x - 1, y);
                else
                    Set(x, y - 1);
             
            }
            else
            {
                if (ori == 0)
                {
                    Set(x - 1, y);
                }
                else if (ori == 1)
                    Set(x, y - 1);
                else if (ori == 2)
                    Set(x + 1, y);
                else
                    Set(x, y + 1);
             
            }
            right = !right;
            
            if (x < 0)
                x = 0;
            else if (x > 4)
                x = 4;
            if (y < 0)
                y = 0;
            else if (y > 5)
                y = 5;
        }
    };
 
    void Start () {
        
        MM = transform.parent.parent.GetComponent<MainMenu>();
        MM.NoAnswer();
        tab = new bool[5,6];
        four = new Fourmi();
        four.right = true;
        four.Set(1, 0);
        lastP = new int[2] { 1, 0 };
        Dev = DeviceOrientation.Unknown;
        stop = false;
	}
    float[] GetPos(bool last)
    {
        float x = 0;
        float y = 0;
        if (last)
        {
            x = lastP[0] * 216;
            y = lastP[1] * 216;
        }
        else
        {
            x = four.x * 216;
            y = four.y * 216;
        }
        return new float[2] { x, -y };
    }
    IEnumerator Move()
    {

        float[] next = GetPos(false);
        float[] prev = GetPos(true);
        float i = 0;
        while(i<1)
        {
            float addx = Mathf.Lerp(prev[0], next[0], i);
            float addy = Mathf.Lerp(prev[1], next[1], i);
            myTran.offsetMax = new Vector2(7 + addx, addy);
            myTran.offsetMin = new Vector2(-7 + addx, addy);
            i += Time.deltaTime*2;
            yield return null;
        }
        lastP[0] = four.x;
        lastP[1] = four.y;
        stop = false;
        if(four.x == 4 && four.y==5)
        {
            MM.GoodAnswert();
        }
    }
    DeviceOrientation[] TOP = new DeviceOrientation[4] { DeviceOrientation.Portrait, DeviceOrientation.LandscapeLeft, DeviceOrientation.PortraitUpsideDown, DeviceOrientation.LandscapeRight };
    DeviceOrientation[] RIGHT = new DeviceOrientation[4] { DeviceOrientation.Portrait, DeviceOrientation.LandscapeLeft, DeviceOrientation.PortraitUpsideDown, DeviceOrientation.LandscapeRight };
    public void Go()
    {
        if (!stop)
        {
            stop = true;
            four.Next();
            StartCoroutine(Move());
        }
    }
    void Update()
    {
     
        if (!stop)
        {
    
            if (Input.deviceOrientation == DeviceOrientation.Portrait)
                four.ori = 0;
            else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
                four.ori = 1;
            else if (Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
                four.ori = 2;
            else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight)
                four.ori = 3;
            Dev = Input.deviceOrientation;
            myTran.eulerAngles = new Vector3(0, 0, -four.ori * 90);
        }
            
    }
	
}
