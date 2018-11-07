using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanoDown : MonoBehaviour
{
    Vector2 startp;
    Vector2 endp;
    RectTransform rekt;
    // Use this for initialization
    void OnEnable()
    {
        startp = new Vector2(0, -1920);
        endp = new Vector2(0, -100);
        rekt = GetComponent<RectTransform>();
        StartCoroutine(GoDown());
        rekt.offsetMax = new Vector2(0, -1920);
        rekt.offsetMin = new Vector2(0, 1920);
    }

    public IEnumerator GoDown()
    {
        float i = 0;
        while (i < 1)
        {
            i += Time.deltaTime;
            Vector2 l = Vector2.Lerp(startp, endp, Mathf.SmoothStep(0, 1, i));
            rekt.offsetMax = -l;
            rekt.offsetMin = -l;
            yield return null;
        }

    }
}
