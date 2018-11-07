using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BombScript2 : MonoBehaviour {
    float i;
    bool potentialwin;
    bool stop;
    [SerializeField]
    Text T;
    [SerializeField]
    MainMenu MM;
    [SerializeField]
    BombScript bmb;
	// Use this for initialization
	void OnEnable () {
        i = 15;
        potentialwin = true;
        stop = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (stop)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                potentialwin = false;
            }
            i -= Time.deltaTime;
            T.text = ((int)i / 60).ToString() + i.ToString("0.00");
            if (i < 0)
            {
                T.text = "0:00";
                stop = false;
                StartCoroutine(waitabit());
            }
        }
	}
    IEnumerator waitabit()
    {
        yield return new WaitForSeconds(0.25f);
        T.enabled = false;
        yield return new WaitForSeconds(0.25f);
        T.enabled = true;
        yield return new WaitForSeconds(0.25f);
        T.enabled = false;
        yield return new WaitForSeconds(0.25f);
        T.enabled = true;
        if (potentialwin)
            MM.GoodAnswert();
        else
        {
            bmb.Refresh();
            gameObject.SetActive(false);
        }

    }
}
