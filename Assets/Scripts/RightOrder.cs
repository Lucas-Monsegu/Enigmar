using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class RightOrder : MonoBehaviour
{
    List<int> buf;
    int tour;
    // Use this for initialization
    void Start()
    {
        tour = 0;
        buf = new List<int>();
        transform.parent.GetComponent<MainMenu>().NoAnswer();
    }

    public void Played(int i)
    {
        transform.GetChild(i + 1).GetComponent<RawImage>().color = new Color(1, 0, 0, 0.2f);
        buf.Add(i);
        tour += 1;
        if (tour >= 6)
        {
            int k;
            for (k = 0; k < buf.Count; k++)
            {
                if (buf[k] != k)
                    k = 10;
            }
            if (k == 6)
                transform.parent.GetComponent<MainMenu>().GoodAnswert();
            else
            {
                for (int t = 1; t < 7; t++)
                {
                    transform.GetChild(t).GetComponent<RawImage>().color = new Color(0, 0, 0, 0);
                }
                buf.Clear();
            }
            tour = 0;

        }
    }
    
    

}
