
using UnityEngine;
using System.Collections;

public class GODown : MonoBehaviour {
    float i;
    float startp;
    public float endp;
	// Use this for initialization
	void Start () {
        startp = transform.position.y;
        i = 0;
	}
	
	// Update is called once per frame
	void Update () {
        i += Time.deltaTime/3;
        transform.position = new Vector2(transform.position.x, Mathf.Lerp(startp, endp, i));
        if (i > 1)
            i = i % 1;
	}
}
