using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    [SerializeField]
    GameObject[] prefabtab;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SpawnLevel(int lvl)
    {
        Clean();
        if (lvl >= 0) {
            GameObject k =(GameObject)Instantiate(prefabtab[lvl]);
            k.transform.SetParent(transform,false);
        }
    }

    public void Clean()
    {
        for(int i =0;i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        } 
    }
 
}
