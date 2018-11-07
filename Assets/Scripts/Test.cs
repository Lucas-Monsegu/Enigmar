using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Test : MonoBehaviour {
    bool b = true;
	public void OnClick()
    {
        b = !b;
        gameObject.SetActive(b);
    }
}
