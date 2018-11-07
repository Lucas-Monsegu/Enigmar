using UnityEngine;
using System.Collections;

public class Scriptcacche : MonoBehaviour {
    bool stop = true;
	void Start () {
        transform.parent.GetComponent<MainMenu>().NoAnswer();
    }
    public void OnClickgood()
    {
        if (stop)
        {
            stop = false;
            transform.parent.GetComponent<MainMenu>().GoodAnswert();
        }
    }
}
