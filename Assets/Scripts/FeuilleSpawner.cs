using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FeuilleSpawner : MonoBehaviour {
    [SerializeField]
    Save s;
    [SerializeField]
    Texture EndBG;
    [SerializeField]
    RawImage mainBG;
    public bool normal = true;
	// Use this for initialization
	void OnEnable () {
        if (normal)
        {
            
            int k = s.ReadGo();
            print(k);
            if (k >= 32)
            {
                mainBG.texture = EndBG;
            }
            else {
                for (int i = 0; i < k; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
        else
            normal = true;
	}
    public void ForceUpdateLeaf()
    {
        int k = s.ReadGo();
        if (k >= 31)
        {
            k = 31;
        }
        for (int i = 0; i < k; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

}
