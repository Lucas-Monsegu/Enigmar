using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BinaryTree : MonoBehaviour {

    int where;
    [SerializeField]
    LineRenderer[] tab;
    [SerializeField]
    RawImage[] tabrond;
    [SerializeField]
    InputField txt;
    bool youcango = true;
	// Use this for initialization
	void Start () {
     
    }

	// Update is called once per frames
	void Update () {
	
	}
    public static int IntParseFast(string value)
    {
        int result = 0;
        for (int i = 0; i < value.Length; i++)
        {
            char letter = value[i];
            result = 10 * result + (letter - 48);
        }
        return result;
    }

    public void OnClickNumber(string num)
    {
        if (youcango&& num.Length!=0)
        {
            txt.interactable = false;
            youcango = false;
            int n = IntParseFast(num);
            if (n == 42)
            {
                where = 4;
            }
            else if (n < 42)
            {
                if (n < 38)
                {
                    where = 1;
                }
                else if(n == 38)
                {
                    where = 2;
                }
                else
                {
                    where = 3;
                }
            }
            else
            {
                if (n < 76)
                {
                    where = 5;
                }
                else if(n == 76)
                {
                    where = 6;
                }
                else
                {
                    where = 7;
                }
            }
            StartCoroutine(New());
        }
    }
    IEnumerator New()
    {
        float i = 0;
        Vector2 start = txt.transform.position;
        Vector2 end = tabrond[0].transform.position;
        tab[0].SetPosition(0,start);
        while (i < 1)
        {
            tab[0].SetPosition(1, Vector2.Lerp(start, end, i));
           
            i += Time.deltaTime * 2;
            yield return null;
        }
        i = 0;
        tabrond[0].color = Color.red;
        if(where<4)
        {
            start = tabrond[0].transform.position;
            end = tabrond[1].transform.position;
            tab[1].SetPosition(0, start);
            while (i < 1)
            {
                tab[1].SetPosition(1, Vector2.Lerp(start, end, i));
                i += Time.deltaTime * 2;
                yield return null;
            }
            i = 0;
            tabrond[1].color = Color.red;
            if (where < 2)
            {
                start = tabrond[1].transform.position;
                end = tabrond[3].transform.position;
                tab[2].SetPosition(0, start);
                while (i < 1)
                {
                    tab[2].SetPosition(1, Vector2.Lerp(start, end, i));
                    i += Time.deltaTime * 2;
                    yield return null;
                }
                tabrond[3].color = Color.red;
            }
            else if(where > 2)
            {
                start = tabrond[1].transform.position;
                end = tabrond[4].transform.position;
                tab[2].SetPosition(0, start);
                while (i < 1)
                {
                    tab[2].SetPosition(1, Vector2.Lerp(start, end, i));
                    i += Time.deltaTime * 2;
                    yield return null;
                }
                tabrond[4].color = Color.red;
            }
        }
        else if (where > 4)
        {
            start = tabrond[0].transform.position;
            end = tabrond[2].transform.position;
            tab[1].SetPosition(0, start);
            while (i < 1)
            {
                tab[1].SetPosition(1, Vector2.Lerp(start, end, i));
                i += Time.deltaTime * 2;
                yield return null;
            }
            i = 0;
            tabrond[2].color = Color.red;
            if (where < 6)
            {
                start = tabrond[2].transform.position;
                end = tabrond[5].transform.position;
                tab[2].SetPosition(0, start);
                while (i < 1)
                {
                    tab[2].SetPosition(1, Vector2.Lerp(start, end, i));
                    i += Time.deltaTime * 2;
                    yield return null;
                }
                tabrond[5].color = Color.red;
            }
            else if(where > 6)
            {
                start = tabrond[2].transform.position;
                end = tabrond[6].transform.position;
                tab[2].SetPosition(0, start);
                while (i < 1)
                {
                    tab[2].SetPosition(1, Vector2.Lerp(start, end, i));
                    i += Time.deltaTime * 2;
                    yield return null;
                }
                tabrond[6].color = Color.red;
            }
            
        }
        yield return new WaitForSeconds(0.5f);
        foreach (LineRenderer k in tab)
        {
            k.SetPosition(0, Vector3.zero);
            k.SetPosition(1, Vector3.zero);
        }
        foreach(RawImage k in tabrond)
        {
            k.color = Color.white;
        }
        youcango = true;
        txt.text = "";
        txt.interactable = true;
    }






    IEnumerator cor()
    {/*
    
        float i = 0;
        RawImage p1;
        RawImage p2;
        if (where == pos.t42)
        {
            while (i < 1)
            {
                tab[0].color = Color.Lerp(Color.white, Color.red, i);
                i += Time.deltaTime * 2;
                yield return null;
            }
            i = 0;
            while (i < 1)
            {
                tabrond[0].color = Color.Lerp(Color.white, Color.red, i);
                i += Time.deltaTime * 2;
                yield return null;
            }
            yield return new WaitForSeconds(2);
            i = 0;
            while (i < 1)
            {
                tab[0].color = Color.Lerp(Color.red, Color.white, i);
                i += Time.deltaTime * 2;
                yield return null;
            }
            i = 0;
            while (i < 1)
            {
                tabrond[0].color = Color.Lerp(Color.red, Color.white, i);
                i += Time.deltaTime * 2;
                yield return null;
            }
        }
        else
        {
            if (where == pos.Left)
            {
                p1 = tab[1];
                p2 = tab[3];
            }
            else if (where == pos.Mleft)
            {
                p1 = tab[1];
                p2 = tab[4];
            }
            else if (where == pos.Mright)
            {
                p1 = tab[2];
                p2 = tab[5];
            }
            else if (where == pos.Right)
            {
                p1 = tab[2];
                p2 = tab[6];
            }
            else if (where == pos.t38)
            {
                p1 = tab[1];
                p2 = tabrond[1];
            }
            else
            {
                p1 = tab[2];
                p2 = tabrond[2];
            }

            while (i < 1)
            {
                tab[0].color = Color.Lerp(Color.white, Color.red, i);
                i += Time.deltaTime * 2;
                yield return null;
            }
            i = 0;
            while (i < 1)
            {
                p1.color = Color.Lerp(Color.white, Color.red, i);
                i += Time.deltaTime * 2;
                yield return null;
            }
            i = 0;
            while (i < 1)
            {
                p2.color = Color.Lerp(Color.white, Color.red, i);
                i += Time.deltaTime * 2;
                yield return null;
            }
            i = 0;
            yield return new WaitForSeconds(2);
            while (i < 1)
            {
                tab[0].color = Color.Lerp(Color.red, Color.white, i);
                i += Time.deltaTime * 2;
                yield return null;
            }
            i = 0;
            while (i < 1)
            {
                p1.color = Color.Lerp(Color.red, Color.white, i);
                i += Time.deltaTime * 2;
                yield return null;
            }
            i = 0;
            while (i < 1)
            {
                p2.color = Color.Lerp(Color.red, Color.white, i);
                i += Time.deltaTime * 2;
                yield return null;
            }
        }*/
        txt.text = "";
        youcango = true;
        yield return null;
    }
}
