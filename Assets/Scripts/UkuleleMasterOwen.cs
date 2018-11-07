using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class UkuleleMasterOwen : MonoBehaviour {
    [SerializeField]
    AudioClip red;
    [SerializeField]
    AudioClip purple;
    [SerializeField]
    AudioClip blue;
    [SerializeField]
    AudioClip green;
    AudioSource[] auds;

    [SerializeField]
    AudioSource FullSource;
    int[] goodanswer = new int[15] { 0,1,2,1,2,3,2,1,0,1,2,1,0,2,1};
    List<int> numli = new List<int>();

    // Use this for initialization
    void Start () {
        transform.parent.GetComponent<MainMenu>().NoAnswer();
        auds =   GetComponents<AudioSource>();

	}
    public void FullSong()
    {
        if (!FullSource.isPlaying)
        {
            FullSource.Play();

        }

    }
	
    public void PlaySong(int i)
    {
        if (!FullSource.isPlaying) {
            
            switch (i)
            {
                case 0://red
                    AudioSource e = FreeAud();
                    e.clip = red;
                    e.Play();
                    break;
                case 1://red
                    AudioSource e1 = FreeAud();
                    e1.clip = purple;
                    e1.Play();
                    break;
                case 2://red
                    AudioSource e2 = FreeAud();
                    e2.clip = blue;
                    e2.Play();
                    break;
                case 3://red
                    AudioSource e3 = FreeAud();
                    e3.clip = green;
                    e3.Play();
                    break;

                default:
                    break;
            }
            if (NumberCompiler(i))
            {
                transform.parent.GetComponent<MainMenu>().GoodAnswert();
            }
        }
    }
    AudioSource FreeAud()
    {
        foreach(AudioSource k in auds)
        {
            if (!k.isPlaying)
                return k;
        }
        return auds[0];
    }
    bool NumberCompiler(int count)
    {
        numli.Add(count);
        if (numli.Count != goodanswer.Length)
            return false;
        else
        {
            int j = 0;
            for (int i = 0; i < goodanswer.Length; i++)
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
            for (int i = goodanswer.Length - j; i < goodanswer.Length; i++)
            {
                k.Add(numli[i]);
            }

            numli = k;

        }
        return false;
    }
    }
