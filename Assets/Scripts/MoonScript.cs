using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoonScript : MonoBehaviour {
    [SerializeField]
    Text tx;
    [SerializeField]
    Save s;
    public void Go()
    {
        int neni = s.ReadGo();
        int nhint = s.ReadAllHint();
        tx.text = "Vous avez résolut " + neni.ToString() + " éngimes et utilisé " + nhint.ToString() + " indices";
        StopCoroutine("GoText");
        StartCoroutine("GoText");
    }
    IEnumerator GoText()
    {
        tx.enabled = true;
        float i = 0;
        Color s = new Color(0,0,0, 0);
        Color e = new Color(0,0,0, 0.58823f);
        while (i < 1)
        {
            tx.color = Color.Lerp(s, e, i);
            i += Time.deltaTime;
            yield return null;
        }
        tx.color = e;
        yield return new WaitForSeconds(2f);
        i = 0;
        while (i < 1)
        {
            tx.color = Color.Lerp(e, s, i);
            i += Time.deltaTime;
            yield return null;
        }
        tx.color = s;
        tx.enabled = false;

    }
    
}
