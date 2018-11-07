using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HintMenu : MonoBehaviour {
    [SerializeField]
    GameObject PC;
    [SerializeField]
    MainMenu MM;
    [SerializeField]
    Save Sa;
    [SerializeField]
    Text TextComp;




    int currentlvl = -1;

    bool Showed = false;

    string currenttext;
    
    private void OnDisable()
    {
        TextComp.enabled = false;
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        PC.SetActive(false);
        Showed = false;

    }

    public void OnLevelFinish()
    {
        if (Showed)
        {
            StopCoroutine(OpenCor());
            StartCoroutine(CloseCor());
            Showed = false;
            PC.SetActive(false);
            TextComp.enabled = false;
        }
    }
   

    public void OnClickAll()
    {
        if (!Showed)
        {
            
            if (currentlvl != -1 || currentlvl != MM.currentlvl)
            {
                ResetColor();
                currentlvl = MM.currentlvl;
            }
            int g = MM.currentlvl;
            if (g > 31)
                g = 31;
            int numofhint = Sa.ReadHint(g);
            if (numofhint > 3)
                numofhint = 3;
            for (int i = 0; i < numofhint; i++)
            {
                Transform k = transform.GetChild(i + 1);
                k.GetComponent<RawImage>().color = Color.white;
                k.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
            }
            StopCoroutine(CloseCor());
            StartCoroutine(OpenCor());
            Showed = true;

        }

        
        else
        {
            StopCoroutine(OpenCor());
            StartCoroutine(CloseCor());
            Showed = false;
            PC.SetActive(false);
            TextComp.enabled = false;
        }

    }
    void ResetColor()
    {
        for (int i = 0; i < 3; i++)
        {
            Transform k = transform.GetChild(i + 1);
            k.GetComponent<RawImage>().color = new Color(1, 1, 1, 0.2549f);
            k.GetChild(0).GetComponent<Text>().text = "...";
        }
    }
    public void OnClickForHint(int hintdyn)
    {
        currentlvl = MM.currentlvl;
        int numofavaiblehint =Sa.ReadHint(currentlvl);
        if (hintdyn == numofavaiblehint+1)
        {
            //Play adds or not

            //Unlock Hint
            Sa.SaveHint(currentlvl);
            Transform k = transform.GetChild(hintdyn);
            k.GetComponent<RawImage>().color = Color.white;
            k.GetChild(0).GetComponent<Text>().text = hintdyn.ToString();
        }
        else if(hintdyn <= numofavaiblehint)
        {
            PC.SetActive(true);
            currenttext = MM.transform.GetChild(0).GetComponent<Hint>().tab[hintdyn-1];
            if (TextComp.enabled)
            {
                StartCoroutine("QuickFade");
            }
            StopCoroutine("OpenText");
            StartCoroutine("OpenText");
            //Show the Hint
        }
    }


    IEnumerator OpenCor()
    {
        RectTransform k1 = transform.GetChild(1).GetComponent<RectTransform>();
        RectTransform k2 = transform.GetChild(2).GetComponent<RectTransform>();
        RectTransform k3 = transform.GetChild(3).GetComponent<RectTransform>();
        k1.gameObject.SetActive(true);
        k2.gameObject.SetActive(true);
        k3.gameObject.SetActive(true);
        float i = 0;
        float startp =0.85f;
        float endp =  0.742f;
        while (i < 1)
        {
            float mediump = Mathf.Lerp(startp, endp, Mathf.Sin(i * Mathf.PI * 0.5f));
            k1.anchorMin = new Vector2(k1.anchorMin[0],mediump);
            k2.anchorMin = new Vector2(k2.anchorMin[0], mediump);
            k3.anchorMin = new Vector2(k3.anchorMin[0], mediump);
            i += Time.deltaTime*2f;
            yield return null;
        }
        k1.anchorMin = new Vector2(k1.anchorMin[0], endp);
        k2.anchorMin = new Vector2(k2.anchorMin[0], endp);
        k3.anchorMin = new Vector2(k3.anchorMin[0], endp);
    }
    IEnumerator CloseCor()
    {
        RectTransform k1 = transform.GetChild(1).GetComponent<RectTransform>();
        RectTransform k2 = transform.GetChild(2).GetComponent<RectTransform>();
        RectTransform k3 = transform.GetChild(3).GetComponent<RectTransform>();

        float i = 0;
        float endp = 0.85f;
        float startp = 0.742f;
        while (i < 1)
        {
            float mediump = Mathf.Lerp(startp, endp, Mathf.SmoothStep(0,1,i));
            k1.anchorMin = new Vector2(k1.anchorMin[0], mediump);
            k2.anchorMin = new Vector2(k2.anchorMin[0], mediump);
            k3.anchorMin = new Vector2(k3.anchorMin[0], mediump);
            i += Time.deltaTime * 2f;
            yield return null;
        }
        k1.gameObject.SetActive(false);
        k2.gameObject.SetActive(false);
        k3.gameObject.SetActive(false);
    }
    IEnumerator QuickFade()
    {
        float i = 0;
        Color start = new Color(1, 1, 1, 0);
        Color end = TextComp.color;
        while (i < 1)
        {
            TextComp.color = Color.Lerp(end, start, Mathf.Sin(i * Mathf.PI * 0.5f));
            i += Time.deltaTime*1.5f;
            yield return null;
        }
        TextComp.color =start;
    }
    IEnumerator OpenText()
    {

        
        float i = 0;
        Color start = new Color(1, 1, 1, 0);
        Color end = new Color(1, 1, 1, 1);
        
        
        yield return new WaitForSeconds(1f);
        TextComp.color = start;
        TextComp.text = currenttext;
        TextComp.enabled = true;
        while (i < 1)
        {
            TextComp.color = Color.Lerp(start, end, Mathf.Sin(i * Mathf.PI * 0.5f));
            i += Time.deltaTime/4;
            yield return null;
        }
        TextComp.color = end;
    }
}
