using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Accelerator : MonoBehaviour {



    [SerializeField]
    Image im;


    float xact;
    float yact;
    float zact;
    float xprev;
    float yprev;
    float zprev;
    float maxsome;
    float prevmaxsome;
    float i = 0;
	// Use this for initialization
	void Start () {
        transform.parent.GetComponent<MainMenu>().NoAnswer();
        if (!SystemInfo.supportsAccelerometer)
            transform.parent.GetComponent<MainMenu>().ErrorLevel();
        xprev = Input.acceleration.x;
        yprev = Input.acceleration.y;
        zprev = Input.acceleration.z;

       
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        CHeck();
        
	}
    void CHeck()
    {
        xact = Input.acceleration.x;
        yact = Input.acceleration.y;
        zact = Input.acceleration.z;
        
        float k = Mathf.Abs(yact - yprev) + Mathf.Abs(xact - xprev) + Mathf.Abs(zact - zprev);
        i += Time.deltaTime;
        im.fillAmount = Mathf.Lerp(prevmaxsome / 7, maxsome / 7, i * 5);
        if (k > maxsome)
            maxsome = k;
        if (i >= 0.2f)
        {
            if (maxsome>=7)
                transform.parent.GetComponent<MainMenu>().GoodAnswert();
            i = 0;
            prevmaxsome = maxsome;
            maxsome = 0;
        }
        
        xprev = xact;
        yprev = yact;
        zprev = zact;
    }
    
}
