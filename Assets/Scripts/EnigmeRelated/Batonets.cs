using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Batonets : MonoBehaviour
{


    bool TotalStop;
    bool playin;
    int advanced;
    int howmany;
    int redplays;
    int i = 0;
    void Start()
    {
        transform.parent.GetComponent<MainMenu>().NoAnswer();
    }
    void OnDisable()
    {
        for (int k = 0; k < 14; k++)
        {
            advanced = 0;
            transform.GetChild(k + 1).GetComponent<RawImage>().color = new Color(1, 1, 1);
        }
    }
    public void Plays(int num)
    {
        if (!TotalStop)
        {
            if (!playin)
            {
                playin = true;
                for (int i = 0; i < num; i++)
                {
                    transform.GetChild(advanced + 1).GetComponent<RawImage>().color = new Color(0.1921f, 0.3647f, 255);
                    advanced++;
                }
                if (advanced >= 14)//win
                {
                    howmany = 0;
                    transform.parent.GetComponent<MainMenu>().GoodAnswert();
                        TotalStop = true;
                }
                if (advanced >= 11)// lose 
                {
                    redplays = (14 - advanced);
                }
                redplays = (14 - advanced) % 4;
                if (redplays == 0)
                {
                    redplays = Random.Range(1,4);
                }
                if (!TotalStop)
                {
                    StartCoroutine(mycor2());
                }
            }

        }
    }

    IEnumerator mycor2()
    {

        while (i < redplays)
        {
            yield return new WaitForSeconds(0.5f);
            transform.GetChild(advanced + 1).GetComponent<RawImage>().color = new Color(255, 0.1921f, 0.1921f);
            advanced++;
            i++;
        }
        i = 0;
        if (advanced == 14)
        {

            for (int k = 0; k < 14; k++)
            {
                advanced = 0;
                transform.GetChild(k + 1).GetComponent<RawImage>().color = new Color(1, 1, 1);
            }
        }
        playin = false;
    }
}
