using UnityEngine;
using System.Collections;

public class ParticleSyst : MonoBehaviour {

	// Use this for initialization
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GoEmit();
    }
	
	public void GoEmit()
    {
        transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        transform.GetChild(1).GetComponent<ParticleSystem>().Play();
        transform.GetChild(2).GetComponent<ParticleSystem>().Play();
    }
}
