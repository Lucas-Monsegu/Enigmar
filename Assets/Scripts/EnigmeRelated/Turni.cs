using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Turni : MonoBehaviour {
    public float speed;
    float i = 0;
    [SerializeField]
    Text tx;
    Vector3 st;
    Vector3 nd;
	// Use this for initialization
	void Start () {
        st = new Vector3(0, 0, 0);
        nd = new Vector3(0, 0, 360);
        Input.gyro.enabled = true;

    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.gyro.enabled)
        {
            tx.text = Input.gyro.rotationRate.z.ToString("F3");
            speed = 0.5f - Input.gyro.rotationRate.z/4;

        }
        else
            tx.text = "not work";
        
        i += Time.deltaTime * speed;
        transform.eulerAngles = Vector3.Lerp(st, nd, i);
        
        if (i >= 1)
            i = i % 1;
        if (i <= 0)
            i = i+1 ;
	}
}
