using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuickFix : MonoBehaviour {
    [SerializeField]
    RectTransform rt;
	// Use this for initialization
	void Start () {
        RectTransform myrt = GetComponent<RectTransform>();
        myrt.offsetMax = new Vector2(0, -rt.rect.height);
        myrt.offsetMin = new Vector2(0, -rt.rect.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
