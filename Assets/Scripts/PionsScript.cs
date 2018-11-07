using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PionsScript : MonoBehaviour
{
    public class Pion
    {
        public int pos;
        public int color;
        public RectTransform im;
        public Pion(int pos, int color, RectTransform im)
        {
            this.pos = pos;
            this.color = color;
            this.im = im;
        }
    };
    int[] tabwin;
    bool stop;
    int[] tab;
    Pion current;
    Pion pion1;
    Pion pion2;
    Pion pion3;
    Pion pion4;
    Pion pion5;
    Pion pion6;
    int lastp;

    [SerializeField]
    RectTransform rec1;
    [SerializeField]
    RectTransform rec2;
    [SerializeField]
    RectTransform rec3;
    [SerializeField]
    RectTransform rec4;
    [SerializeField]
    RectTransform rec5;
    [SerializeField]
    RectTransform rec6;


    void Start()
    {
        tab = new int[7] { 1, 1, 1, 0, 2, 2, 2 };

        tabwin = new int[7] { 2, 2, 2, 0, 1, 1, 1 };
        pion1 = new Pion(0, 1, rec1);
        pion2 = new Pion(1, 1, rec2);
        pion3 = new Pion(2, 1, rec3);
        pion4 = new Pion(4, 2, rec4);
        pion5 = new Pion(5, 2,rec5);
        pion6 = new Pion(6, 2, rec6);
        stop = false;
        transform.parent.GetComponent<MainMenu>().NoAnswer();
        Reset();
    }
    public void Reset()
    {
        tab = new int[7] { 1, 1, 1, 0, 2, 2, 2 };
        pion1.pos = 0;
        pion2.pos = 1;
        pion3.pos = 2;
        pion4.pos = 4;
        pion5.pos = 5;
        pion6.pos = 6;
        pion1.im.offsetMax = new Vector2(0, 0);
        pion1.im.offsetMin = new Vector2(0, 0);
        pion2.im.offsetMax = new Vector2(154, 0);
        pion2.im.offsetMin = new Vector2(154, 0);
        pion3.im.offsetMax = new Vector2(308, 0);
        pion3.im.offsetMin = new Vector2(308, 0);
        pion4.im.offsetMax = new Vector2(616, 0);
        pion4.im.offsetMin = new Vector2(616, 0);
        pion5.im.offsetMax = new Vector2(770, 0);
        pion5.im.offsetMin = new Vector2(770, 0);
        pion6.im.offsetMax = new Vector2(924, 0);
        pion6.im.offsetMin = new Vector2(924, 0);
    }
    public void OnClick(int but)
    {
        if (!stop)
        {
            if (but == 1)
                current = pion1;
            else if (but == 2)
                current = pion2;
            else if (but == 3)
                current = pion3;
            else if (but == 4)
                current = pion4;
            else if (but == 5)
                current = pion5;
            else
                current = pion6;


            lastp = current.pos;
            if (current.color == 1)
            {
                if (current.pos < 6)
                {
                    if (tab[current.pos + 1] == 0)
                    {
                        Trade(current.pos, current.pos + 1);
                        current.pos += 1;
                    }
                    else if (current.pos < 5 && tab[current.pos + 2] == 0)
                    {
                        Trade(current.pos, current.pos + 2);
                        current.pos += 2;
                    }
                }
            }
            else if (current.color == 2)
            {
                if (current.pos > 0)
                {
                    if (tab[current.pos - 1] == 0)
                    {
                        Trade(current.pos, current.pos - 1);
                        current.pos -= 1;
                    }
                    else if (current.pos > 1 && tab[current.pos - 2] == 0)
                    {
                        Trade(current.pos, current.pos - 2);
                        current.pos -= 2;
                    }
                }
            }
            if (lastp != current.pos)
            {
                StartCoroutine(MoveNext());
            }
        }
    }
    void Trade(int x1, int x2)
    {
        int save = tab[x1];
        tab[x1] = tab[x2];
        tab[x2] = save;
    }
    IEnumerator MoveNext()
    {
        current.im.transform.SetSiblingIndex(8);
        stop = true;
        float i = 0;
        int reallastp = lastp * 154;
        int realp = current.pos * 154;
        while (i < 1)
        {
            float movingp = Mathf.Lerp(reallastp, realp, i);

            current.im.offsetMax = new Vector2(movingp, 0);
            current.im.offsetMin = new Vector2(movingp, 0);
            if (i < 0.5f)
                current.im.localScale = new Vector2(1 + i, 1 + i);
            else
                current.im.localScale = new Vector2(2 - i, 2 - i);
            i += Time.deltaTime*2;
            yield return null;
        }
        current.im.offsetMax = new Vector2(realp, 0);
        current.im.offsetMin = new Vector2(realp, 0); 
        current.im.localScale = new Vector2(1, 1);
        stop = false;
        CheckWin();

    }
    void CheckWin()
    {


        bool b = true;
        for(int i = 0; i < tab.Length; i++)
        {
            if(tab[i]!= tabwin[i])
            {
                b = false;
                break;
            }
        }
        if (b)
        {
            transform.parent.GetComponent<MainMenu>().GoodAnswert();
        }
    }
    
}
