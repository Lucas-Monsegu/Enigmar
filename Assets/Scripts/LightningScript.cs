using UnityEngine;
//using DigitalRuby.ThunderAndLightning;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class LightningScript : MonoBehaviour
{
    
    [SerializeField]
    RawImage light1;
    int fingers;
    bool test;
    // Use this for initialization
    void Start()
    {
        transform.parent.GetComponent<MainMenu>().NoAnswer();
        Application.targetFrameRate = 25;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {

                    fingers += 1;
                    UpdateLight();
                    if (fingers == 5)
                    {
                        transform.parent.GetComponent<MainMenu>().GoodAnswert();
                    }

                }
                else if (Input.GetTouch(i).phase == TouchPhase.Ended)
                {

                    test = true;
                    if (fingers > 0)
                        fingers -= 1;
                    UpdateLight();
                }


            }

        }
        else
        {
            if (test)
            {
                fingers = 0;
                UpdateLight();
            }
        }

    }
    void UpdateLight()
    {
        float e = (51f * fingers) / 255;
        light1.color = new Color(1, 1, 1, e);
    }

}

