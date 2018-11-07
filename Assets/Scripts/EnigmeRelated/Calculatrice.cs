using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DigitalRuby.ThunderAndLightning;

public class Calculatrice : MonoBehaviour {
    
    int[,,] Tab0;
    int[,,] Tab1;
    int[,,] Tab2;
    public struct Cdonne
    {
        public int x, y;

        public Cdonne(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }
    int toadd;
    [SerializeField]
    Text tx;
    
    int[,,] currenttab;
    int currentsomme;
    DigitalRuby.ThunderAndLightning.LightningBoltPathScript lightpath;

    int currentlvl;
    Cdonne coord;
    


    List<GameObject> tabez;

    Cdonne Tofind;
    // Use this for initialization
    void Start()
    {
        //Tab2 = new int[4, 4, 2] { { { 1, 13 }, { 0, -5 }, { 0, 3 }, { 0, 3 } }, { { 0, -4 }, { 0, 1 }, { 0, -1 }, { 0, -4 } }, { { 0, 3 }, { 0, -6 }, { 0, 2 }, { 0, -7 } }, { { 0, 5 }, { 0, 2 }, { 0, -3 }, { 0, 0 } } };
        Tab2 = new int[4, 4, 2] { { { 1, 5 }, { 0, 1 }, { 0, -4 }, { 0, 6 } }, { { 0, -7 }, { 0, 2 }, { 0, -9 }, { 0, 1 } }, { { 0, 3 }, { 0, -6 }, { 0, 5 }, { 0, -2 } }, { { 0, 8 }, { 0, 1 }, { 0, -1 }, { 0, 4 } } };
        Tab1 = new int[4, 4, 2] { { { 1, 8 }, { 0, 3 }, { 0, 1 }, { 0, 4 } }, { { 0, 2 }, { 0, 6 }, { 0, 2 }, { 0, -6 } }, { { 0, 3 }, { 0, -5 }, { 0, 3 }, { 0, -2 } }, { { 0, 4 }, { 0, -5 }, { 0, 2 }, { 0, 9 } } };


        coord = new Cdonne(0, 0);
        lightpath = GetComponent<LightningBoltPathScript>();

        currentsomme = 4;
        toadd = 1;
        Tofind = new Cdonne(3, 3);

        currentlvl = 0;
        currenttab = new int[4, 4, 2] { { { 1, 4 }, { 0, 3 }, { 0, -6 }, { 0, 9 } }, { { 0, -2 }, { 0, -5 }, { 0, 7 }, { 0, -1 } }, { { 0, 7 }, { 0, 3 }, { 0, -2 }, { 0, -4 } }, { { 0, 1 }, { 0, -6 }, { 0, 4 }, { 0, -1} } };
        tabez = new List<GameObject> { lightpath.LightningPath.List[0], lightpath.LightningPath.List[1] };

        transform.parent.GetComponent<MainMenu>().NoAnswer();
    }
   
    public void Left()
    {

        if (coord.x - 1 >= 0)
        {


            coord.x -= 1;
            if (currenttab[coord.x, coord.y, 0] == 0)
            {
                toadd++;
                currenttab[coord.x, coord.y, 0] = toadd;
                currentsomme += currenttab[coord.x, coord.y, 1];
                lightpath.LightningPath.List.Add(GetGO(coord.x, coord.y));
                
            }
            else if (currenttab[coord.x, coord.y, 0] == toadd - 1)
            {
                toadd--;
                currenttab[coord.x + 1, coord.y, 0] = 0;
                currentsomme -= currenttab[coord.x + 1, coord.y, 1];
                lightpath.LightningPath.List.RemoveAt(lightpath.LightningPath.List.Count - 1);
                
            }
            else
                coord.x += 1;
            CheckMaths();
        }
    }
    public void Right()
    {

        if (coord.x + 1 < 4)
        {
            coord.x += 1;
            if (currenttab[coord.x, coord.y, 0] == 0)
            {
                toadd++;
                currenttab[coord.x, coord.y, 0] = toadd;
                currentsomme += currenttab[coord.x, coord.y, 1];
                GameObject getgo = GetGO(coord.x, coord.y);
                lightpath.LightningPath.List.Add(GetGO(coord.x, coord.y));
              
            }
            else if (currenttab[coord.x, coord.y, 0] == toadd - 1)
            {
                toadd--;
                currenttab[coord.x - 1, coord.y, 0] = 0;
                currentsomme -= currenttab[coord.x - 1, coord.y, 1];
                lightpath.LightningPath.List.RemoveAt(lightpath.LightningPath.List.Count - 1);
                

            }
            else
                coord.x -= 1;
            CheckMaths();

        }
       
    }

    public void Up()
    {

        if (coord.y - 1 >= 0)
        {
            coord.y -= 1;
            if (currenttab[coord.x, coord.y, 0] == 0)
            {
                toadd++;
                currenttab[coord.x, coord.y, 0] = toadd;
                currentsomme += currenttab[coord.x, coord.y, 1];
                lightpath.LightningPath.List.Add(GetGO(coord.x, coord.y));
               
            }
            else if (currenttab[coord.x, coord.y, 0] == toadd - 1)
            {
                toadd--;
                currenttab[coord.x, coord.y + 1, 0] = 0;
                currentsomme -= currenttab[coord.x, coord.y + 1, 1];
                lightpath.LightningPath.List.RemoveAt(lightpath.LightningPath.List.Count - 1);
                
            }
            else
                coord.y += 1;
            CheckMaths();

        }
    }
    public void Down()
    {
        if (coord.y + 1 < 4)
        {
            coord.y += 1;
            if (currenttab[coord.x, coord.y, 0] == 0)
            {
                toadd++;
                currenttab[coord.x, coord.y, 0] = toadd;
                currentsomme += currenttab[coord.x, coord.y, 1];
                lightpath.LightningPath.List.Add(GetGO(coord.x, coord.y));
               
            }
            else if (currenttab[coord.x, coord.y, 0] == toadd - 1)
            {
                toadd--;
                currenttab[coord.x, coord.y - 1, 0] = 0;
                currentsomme -= currenttab[coord.x, coord.y - 1, 1];
                lightpath.LightningPath.List.RemoveAt(lightpath.LightningPath.List.Count - 1);
               
            }
            else
                coord.y -= 1;
            CheckMaths();


        }
    }
    void CheckMaths()
    {

        if (coord.y == 3 )
        {

            if (currentsomme == 0)
            {
                if (currentlvl == 1)
                    transform.parent.GetComponent<MainMenu>().GoodAnswert();
                else
                   StartCoroutine(Anim());//changelevel(++currentlvl);
                currentlvl++;

                
            }
        }
    }
    IEnumerator Anim() {
        currentsomme = 7;
        yield return new WaitForSeconds(0.5f);
        float i = 0;
        RectTransform[] k = new RectTransform[16];
        Color red = new Color(1, 0.1529f, 0.1529f);
        Color green = new Color(0.1529f, 1, 0.2235f); 
        currenttab = Tab2;

        bool[] btab = new bool[16] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

        int child = 16;
        lightpath.LightningPath.List.Clear();
        lightpath.CountProbabilityModifier = 0;
        lightpath.LightningPath.List = tabez;
        while (i < 1)
        {
            for (int z = 0; z < child; z++)
            {
                if (i == 0)
                {
                    k[z] = transform.GetChild(z+1).GetComponent<RectTransform>();
                }
                float f = Mathf.Lerp(1, -1, (i * 2) - ((float)z / 16));
                if (f < 0)
                {
                    if (!btab[z])
                    {
                        int tmp = currenttab[z % 4, z / 4, 1];
                        if (tmp < 0)
                            k[z].GetComponent<RawImage>().color = red;
                        else
                            k[z].GetComponent<RawImage>().color = green;

                        k[z].GetChild(0).GetComponent<Text>().text = Mathf.Abs(tmp).ToString();
                        
                        btab[z] = true;
                    }
                    f = -f;
                }
                k[z].localScale = new Vector2(1, f);
            }
            i += Time.deltaTime;
            yield return null;
        }
        tx.text = 2.ToString();

        toadd = 1;
        coord.x = 0;
        coord.y = 0;




    }
    public void Iplayed(int i)
    {
        
        int y = i / 4;
        int x = i % 4;
        if (coord.x == x)
        {
            if (coord.y == y - 1)
                Down();
            else if (coord.y == y + 1)
                Up();
        }
        else if (coord.y == y)
        {
            if (coord.x == x - 1)
                Right();
            else if (coord.x == x + 1)
                Left();
        }
        lightpath.CountProbabilityModifier = 0.1f * (lightpath.LightningPath.List.Count - 2);
    }

    void clearall()
    {
        

        lightpath.LightningPath.List = new List<GameObject> { tabez[0], tabez[1] };
        coord.x = 0;
        coord.y = 0;
    }


    GameObject GetGO(int x, int y)
    {
        return transform.GetChild(x+1+4*y).gameObject;
    }
}
