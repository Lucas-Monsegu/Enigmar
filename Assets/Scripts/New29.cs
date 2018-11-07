using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DigitalRuby.ThunderAndLightning;

public class New29 : MonoBehaviour {
    [SerializeField]
    AudioSource aud;
    [SerializeField]
    AudioClip[] clips;
    [SerializeField]
    Text tx;

    [SerializeField]
    LightningBoltScript lbot;
    [SerializeField]
    AudioSource aud2;
    Vector2 start;
    float lastrot;
    float lastframe;

    bool firststop = false;
    short compteur;
    int[] goodanswer = new int[12] { 6, 4, 5, 10, 5, 2, 1, 8, 3, 7, 5, 2 };
    //int[] goodanswer = new int[5] { 1,2,3,4,5 };

    List<int> numli = new List<int>();
	// Use this for initialization
	void Start () {
        compteur = 0;
        transform.parent.parent.GetComponent<MainMenu>().NoAnswer();
	}
    short cross(Vector2 lol)
    {
        float wo = Vector3.Cross(lol, start).z;
        if (wo >= 1)
            return -1;
        else
            return 1;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButtonDown(0))
        {

            start = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            start = new Vector2(start.x - transform.position.x, start.y - transform.position.y);
            lastrot = transform.eulerAngles.z;
            firststop = false;
            lastframe = lastrot;
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (NumberCompiler(compteur))
            {
                StartCoroutine(YOUWON());
            }
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 lol = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lol = new Vector2(lol.x - transform.position.x, lol.y - transform.position.y);

            
            float calc = Vector2.Angle(lol,start) * cross(lol);
            
            calc = lastrot + calc;
            transform.eulerAngles = new Vector3(0, 0,  calc);

            
            float z = transform.eulerAngles.z;
            if (lastframe == 0)
            {
                if(z < 350)
                {
                    transform.eulerAngles = Vector3.zero;

                }
            }
            else
            {
                if(lastframe-z > 20)
                {
                    transform.eulerAngles = Vector3.zero;
                }

                
            }
            lastframe = transform.eulerAngles.z;

        }
        else
        {
            if(transform.eulerAngles.z != 0)
            {
                if (!firststop)
                {
                    aud.clip = clips[1];
                    aud.loop = true;
                    aud.Play();
                    firststop = true;
                }
                float a = transform.eulerAngles.z + 360 * Time.deltaTime;
                if (a > 360)
                {
                    a = 0;
                }
                transform.eulerAngles = new Vector3(0, 0, a);
               
            }
            else if(firststop)
            {
                aud.clip = clips[0];
                aud.loop = false;
                aud.Play();
                firststop = false;
            }
            

        }

        /*
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                start = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                start = new Vector2(start.x - transform.position.x, start.y - transform.position.y);
                lastrot = transform.eulerAngles.z;
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (NumberCompiler(compteur))
                {
                    StartCoroutine(YOUWON());
                }
            }

            else
            {
                Vector2 lol = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                lol = new Vector2(lol.x - transform.position.x, lol.y - transform.position.y);


                float calc = Vector2.Angle(lol, start) * cross(lol);

                transform.eulerAngles = new Vector3(0, 0, lastrot + calc);
                float z = transform.eulerAngles.z;
                if (lastframe == 0)
                {
                    if (z < 350)
                    {
                        transform.eulerAngles = Vector3.zero;

                    }
                }
                else
                {
                    if (lastframe - z > 20)
                    {
                        transform.eulerAngles = Vector3.zero;
                    }
                    

                }
                lastframe = transform.eulerAngles.z;
            }
        }
        else
        {
            if (transform.eulerAngles.z != 0)
            {
                if (!firststop)
                {
                    aud.clip = clips[1];
                    aud.loop = true;
                    aud.Play();
                    firststop = true;
                }
                float a = transform.eulerAngles.z + 360 * Time.deltaTime;
                if (a > 360)
                {
                    a = 0;
                }
                transform.eulerAngles = new Vector3(0, 0, a);

            }
            else if (firststop)
            {
                aud.clip = clips[0];
                aud.loop = false;
                aud.Play();
                firststop = false;
            }

        }*/
        checkcompt();
    }
    IEnumerator YOUWON()
    {

        
        yield return new WaitForSeconds(1f);
        aud2.Play();
        Vector3 a = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width ), -Screen.width/2, 0));
        Vector3 b = new Vector3(a.x, -a.y, 0);
        callLight(a,b);
        a = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2), -Screen.width / 2, 0));
        b = new Vector3(a.x, -a.y, 0);
        callLight(a, b);
        yield return new WaitForSeconds(0.25f);
        a = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2), -Screen.width / 2, 0));
        b = new Vector3(a.x, -a.y, 0);
        callLight(a, b);
        a = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2), -Screen.width / 2, 0));
        b = new Vector3(a.x, -a.y, 0);
        callLight(a, b);
        yield return new WaitForSeconds(0.25f);
        a = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2), -Screen.width / 2, 0));
        b = new Vector3(a.x, -a.y, 0);
        callLight(a, b);
        a = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2), -Screen.width / 2, 0));
        b = new Vector3(a.x, -a.y, 0);
        callLight(a, b);
        a = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2), -Screen.width / 2, 0));
        b = new Vector3(a.x, -a.y, 0);
        callLight(a, b);
        a = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2), -Screen.width / 2, 0));
        b = new Vector3(a.x, -a.y, 0);
        callLight(a, b);
        yield return new WaitForSeconds(0.25f);
        a = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2), -Screen.width / 2, 0));
        b = new Vector3(a.x, -a.y, 0);
        callLight(a, b);
        a = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2), -Screen.width / 2, 0));
        b = new Vector3(a.x, -a.y, 0);
        callLight(a, b);
        yield return new WaitForSeconds(0.25f);
        a = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2), -Screen.width / 2, 0));
        b = new Vector3(a.x, -a.y, 0);
        callLight(a, b);
        a = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2), -Screen.width / 2, 0));
        b = new Vector3(a.x, -a.y, 0);
        callLight(a, b);
        a = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2), -Screen.width / 2, 0));
        b = new Vector3(a.x, -a.y, 0);
        callLight(a, b);
        yield return new WaitForSeconds(0.1f);
        transform.parent.parent.GetComponent<MainMenu>().GoodAnswert();

    }
    bool NumberCompiler(int count)
    {
        if (count == 0)
            return false;
        numli.Add(count);

        if (numli.Count != goodanswer.Length)
            return false;

        else
        {
            int j = 0;
            for(int i= 0; i < goodanswer.Length; i++)
            {
                if (goodanswer[j] == numli[i])
                {
                    j++;
                }
                else
                    j = 0; 

            }
            if (j == goodanswer.Length)
                return true;
            List<int> k = new List<int>();
            for(int i = goodanswer.Length - j; i < goodanswer.Length; i++)
            {

                k.Add(numli[i]);
            }
            
            numli = k;

        }
        return false;
        
    }
    void callLight(Vector3 start2, Vector3 end2)
    {

        // Important, make sure this script is assigned properly, or you will get null ref exceptions.
        DigitalRuby.ThunderAndLightning.LightningBoltScript script = lbot;
        int count = 1;
        float duration = 0.25f;
        float delay = 0.0f;
        int seed = -925357487;
        System.Random r = new System.Random();
        Vector3 start = start2;
        Vector3 end = end2;
        int generations = 6;
        float chaosFactor = 0.28f;
        float trunkWidth = 0.35f;
        float glowIntensity = 0.6f;
        float glowWidthMultiplier = 4f;
        float forkedness = 0.6f;
        float singleDuration = Mathf.Max(1.0f / 30.0f, (duration / (float)count));
        float fadePercent = 0.15f;
        float growthMultiplier = 0f;

        while (count-- > 0)
        {
            DigitalRuby.ThunderAndLightning.LightningBoltParameters parameters = new DigitalRuby.ThunderAndLightning.LightningBoltParameters
            {
                Start = start,
                End = end,
                Generations = generations,
                LifeTime = (count == 1 ? singleDuration : (singleDuration * (((float)r.NextDouble() * 0.4f) + 0.8f))),
                Delay = delay,
                ChaosFactor = chaosFactor,
                TrunkWidth = trunkWidth,
                GlowIntensity = glowIntensity,
                GlowWidthMultiplier = glowWidthMultiplier,
                Forkedness = forkedness,
                Random = r,
                FadePercent = fadePercent, // set to 0 to disable fade in / out
                GrowthMultiplier = growthMultiplier
            };
            script.CreateLightningBolt(parameters);
            delay += (singleDuration * (((float)r.NextDouble() * 0.8f) + 0.4f));
        }
    }
    void checkcompt()
    {
        float z = transform.eulerAngles.z;
        if (z > 310)
        {
            compteur = 0;
        }
        else if (z > 280)
        {
            compteur = 1;
        }
        else if (z > 250)
        {
            compteur = 2;
        }
        else if (z > 220)
        {
            compteur = 3;
        }
        else if (z > 190)
        {
            compteur = 4;
        }
        else if (z > 160)
        {
            compteur = 5;
        }
        else if (z > 130)
        {
            compteur = 6;
        }
        else if (z > 100)
        {
            compteur = 7;
        }
        else if (z > 70)
        {
            compteur = 8;
        }
        else if (z > 40)
        {
            compteur = 9;
        }
        else if (z > 10)
        {
            compteur = 10;
        }

        if (compteur == 0)
            tx.text = "";
        else if (compteur == 10)
            tx.text = "0";
        else
            tx.text = compteur.ToString();
    }
}
