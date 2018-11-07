using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimEnd : MonoBehaviour {
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject part;
    [SerializeField]
    UnityStandardAssets.ImageEffects.BloomAndFlares bloom;
    [SerializeField]
    Texture newIm;
    [SerializeField]
    RawImage BackGround;
    [SerializeField]
    Text textremerciement;
    [SerializeField]
    ParticleSystem partexplo;

    bool once;
    bool stop;
    float petiti = 0;
    float i = -2.5f;
    float[] tab;
    float[] rottab;
    float topscreen;
    bool go;
    bool decreasing;
    void Start()
    {
        GetComponent<FeuilleSpawner>().ForceUpdateLeaf();
        once = true;
        stop = false;
        decreasing = false;
        go = true;
        part.SetActive(true);
        menu.SetActive(false);
        tab = new float[transform.childCount-2];
        rottab = new float[transform.childCount-2];
        for (int z = 0; z < transform.childCount-2; z++)
        {
            tab[z] = transform.GetChild(z).position.y;
            rottab[z] = transform.GetChild(z).eulerAngles.z;
        }
        
    }
    IEnumerator showendmessage()
    {
        part.GetComponent<ParticleSystem>().Stop();
        yield return new WaitForSeconds(2f);
        textremerciement.gameObject.SetActive(true);
        Color start = new Color(0, 0, 0, 0);
        Color end = new Color(1, 1, 1, 1);
        float i = 0;
        while (i < 1)
        {
            textremerciement.color = Color.Lerp(start, end, i);
            i += Time.deltaTime / 3;
            yield return null;
        }
       
        yield return new WaitForSeconds(10);
        i = 0;
        while (i < 1)
        {
            textremerciement.color = Color.Lerp(end, start, i);
            i += Time.deltaTime / 3;
            yield return null;
        }
        textremerciement.gameObject.SetActive(false);
        partexplo.gameObject.SetActive(false);
        menu.SetActive(true);
    }
    void Update()
    {
        if (!stop)
        {
            if (decreasing)
            { 
                if (petiti < 1&&once)
                {
                    partexplo.gameObject.SetActive(true);
                    partexplo.Emit(50);
                    once = false;
                }
                bloom.bloomIntensity = petiti;
                petiti -= calcPI(petiti);
                if (petiti <= 0)
                {
                    bloom.enabled = false;
                    StartCoroutine(showendmessage());
                    stop = true;
                }
            }
            else
            {
                if (i >= 13.5f)
                {

                    if (petiti > 16)
                    {
                        decreasing = true;
                    }
                    else if (petiti >= 15 && petiti <= 16)
                    {
                        if (go)
                        {
                            go = false;
                            BackGround.texture = newIm;
                        }
                    }
                    else
                    {
                        bloom.enabled = true;
                        bloom.bloomIntensity = petiti;

                    }
                    petiti += calcPI(petiti);
                }
                else
                {
                    for (int z = 0; z < transform.childCount - 2; z++)
                    {
                        Transform o = transform.GetChild(z);
                        float le = Mathf.Lerp(tab[z], 20, (i - ((float)z / 3)) / 2);
                        o.position = new Vector2(o.position.x, le);
                        o.eulerAngles = new Vector3(0, 0, Mathf.Lerp(rottab[z], -360, ((i - ((float)z / 3))) / 2));

                    }
                }
                i += Time.deltaTime / 4;
            }
        }
    }
    float calcPI(float a)
    {
        if (a < 1)
        {
            return Time.deltaTime;
        }
        else
        {
            return 5 * Time.deltaTime;
        }
    }
}
