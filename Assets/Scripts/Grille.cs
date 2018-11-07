using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Grille : MonoBehaviour {
    bool[] tab = new bool[36] {  false, false, false, false, false, false ,  false, false, false, false, false, false,  false, false, false, false, false, false ,  false, false, false, false, false, false , false, false, false, false, false, false ,  false, false, false, false, false, false  };
    bool[] sol = new bool[36] { true, false, false, true, false, false, false, false, true, false, false, true, false, true, true, true, false, true, true, false, true, true, false, false, true, true, false, false, false, false, false, true, true, false, false, false, };
    Color red = new Color(1, 0, 0, 1);
    Color blank = new Color(1, 0, 0, 0);
    void Start()
    {
        transform.parent.GetComponent<MainMenu>().NoAnswer();
    }
    public void IPlayed(int n)
    {
        
        if(tab[n])
        {
            tab[n] = false;
            transform.GetChild(n + 2).GetComponent<RawImage>().color = blank;
        }
        else
        {
            tab[n] = true;
            transform.GetChild(n + 2).GetComponent<RawImage>().color = red;
        }
        Check();
    }
    private void Check()
    {
        for(short i = 0; i < 36; i++)
        {
            if (tab[i] != sol[i])
                return;
        }
        transform.parent.GetComponent<MainMenu>().GoodAnswert();
    }
}
