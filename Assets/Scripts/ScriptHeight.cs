using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScriptHeight : MonoBehaviour {
    [SerializeField]
    Slider slide0;
    [SerializeField]
    Slider slide1;
    [SerializeField]
    Slider slide2;
    [SerializeField]
    Slider slide3;
    float K0;
    float K1;
    float K2;
    float K3;
    bool waitabit;
	// Use this for initialization
	void Start () {
        transform.parent.GetComponent<MainMenu>().NoAnswer();
        waitabit = false;
        K0 = 0.5f;
        K1 = 0.5f;
        K2 = 0.5f;
        K3 = 0.5f;
        
    }

    public void ValueChange0()
    {
        K0 = slide0.value;
        Check();
    }
    public void ValueChange1()
    {
        K1 = slide1.value;
        Check();
    }
   public  void ValueChange2()
    {
        K2 = slide2.value;
        Check();
    }
   public void ValueChange3()
    {
        K3 = slide3.value;
        Check();
    }

    void Check()
    {
        if(K0>K1&& K3>K0&& K2>K3)
        {
            if (!waitabit)
            {
                waitabit = true;
                StartCoroutine(wait());
                
            }
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        if (K0 > K1 && K3 > K0 && K2 > K3)
            transform.parent.GetComponent<MainMenu>().GoodAnswert();
        else
            waitabit = false;
    }
}
