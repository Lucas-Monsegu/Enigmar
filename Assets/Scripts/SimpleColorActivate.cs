using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SimpleColorActivate : MonoBehaviour {
    RawImage k;
	// Use this for initialization
	void Start () {
       k = GetComponent<RawImage>();

	}
    IEnumerator za()
    {
        k.color = new Color(k.color.r, k.color.g, k.color.b, 0.47f);
        yield  return new WaitForSeconds(0.5f);
        k.color = new Color(k.color.r, k.color.g, k.color.b, 0.0f);
    }
	public void OnChange()
    {
        StartCoroutine(za());
    }

   
}
