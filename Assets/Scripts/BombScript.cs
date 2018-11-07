using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BombScript : MonoBehaviour
{
    float i = 0;

    [SerializeField]
    Texture ON;
    [SerializeField]
    Texture OFF;
    [SerializeField]
    RawImage myIm;
    [SerializeField]
    GameObject bombpan;
    [SerializeField]
    MainMenu MM;
    bool b1;
    bool b2;
    bool b3;
    bool goOn;
    bool goOn2;
    bool T1;
    void Start()
    {
        Refresh();
    }
    public void Refresh()
    {
        i = 5;
        T1 = true;
        MM.NoAnswer();
        b1 = false;
        b2 = false;
        b3 = false;
        goOn = false;
        goOn2 = false;
       
    }
    // Update is called once per frame
    void Update()
    {
        i += Time.deltaTime;
        if (i <2f)
        {
            myIm.texture = ON;
            b1 = true;
        }
        else if (i < 3)
        {
            myIm.texture = OFF;
            b1 = false;

        }
        else if (i < 3.5)
        {
            myIm.texture = ON;
            b2 = true;
        }
        else if (i < 4)
        {
            myIm.texture = OFF;
            b2 = false;
            goOn = false;
        }
        else if(i<4.5f)
        {
            myIm.texture = ON;
            b3 = true;
            
        }

        else if(i<5)
        {
            myIm.texture = OFF;
            b3 = false;
            goOn2 = false;
        }
        else
        {
            i = i % 6;
        }
        if(T1)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
            {

                if (b1)
                {
                    goOn = true;

                }
                if (b2 && goOn)
                {

                    goOn2 = true;
                }
                if (b3 && goOn2)
                {
                    bombpan.SetActive(true);
                    T1 = false;
                }
                if (!b1 && !b2 && !b3)
                {
                    goOn = false;
                    goOn2 = false;
                }
            }
        }
    }
}
