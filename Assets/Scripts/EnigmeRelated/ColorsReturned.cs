using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ColorsReturned : MonoBehaviour {
    List<int> li;
    bool victory = false;

    int[] soluce = new int[5] { 0, 2, 0, 1, 3 };
    void Start()
    {
        li = new List<int>();
        transform.parent.GetComponent<MainMenu>().NoAnswer();
    }
    void printli()
    {

    }
    public void NumPushed(int count)
    {
        if (!victory)
        {
            li.Add(count);

            if (li.Count != soluce.Length)
                return;

            else
            {

                int j = 0;
                for (int i = 0; i < soluce.Length; i++)
                {
                    if (soluce[j] == li[i])
                    {
                        j++;
                    }
                    else
                        j = 0;

                }

                if (j == soluce.Length)
                {
                    transform.parent.GetComponent<MainMenu>().GoodAnswert();
                    victory = true;
                    return;
                }
                List<int> k = new List<int>();
                for (int i = soluce.Length - j; i < soluce.Length; i++)
                {
                    k.Add(li[i]);
                }

                li = k;


            }
        }
    }
/*
    public void Pushed(int k)
    {
        if (!victory)
        {
            li.Add(k);
            printli();
            print("L1");
            for (int i = 0; i < li.Count; i++)
            {
                print(soluce[i]);
                print(li[i] + "," + soluce[i]);
                if (li[i] != soluce[i])
                {
                    print("dif");
                    li = new List<int>();
                }
            }
            printli();
            print("L2");
            if (li.Count == 5)
            {
                print("victory");
                victory = true;
                transform.parent.GetComponent<MainMenu>().GoodAnswert();
            }
        }
    }*/
}
