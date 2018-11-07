using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
    [SerializeField]
    GameObject UITOP;
    [SerializeField]
    Save save;
    [SerializeField]
    GameObject butonMM;
    [SerializeField]
    ParticleSyst parts;
    [SerializeField]
    PanoDown pano;
    [SerializeField]
    Text LvlTxt;
    [SerializeField]
    RectTransform mainpanel;
    [SerializeField]
    RectTransform niveaux;
    [SerializeField]
    LevelManager lvlman;
    [SerializeField]
    Texture goldenarrow;
    [SerializeField]
    HintMenu HM;
    [SerializeField]
    RectTransform rt;

    [SerializeField]
    AnimEnd anim;

    [SerializeField]
    Texture noantexture;
    [SerializeField]
    Texture antexture;

    [SerializeField]
    RectTransform aboutpan;
    [SerializeField]
    GameObject errortxt;

    [SerializeField]
    GameObject feuilles;

    public bool forcelvl;
    bool InMenu;
    Vector2 bottom;
    bool isleft = true;

    public int currentlvl;
    void Start()
    {
        InMenu = true;
        bottom = new Vector2(0, rt.rect.height);
        Application.targetFrameRate = 30;
        
    }
    public void ErrorLevel()
    {
        errortxt.SetActive(true);
        GoodAnswert();
    }
    
    void Reset()
    {
        errortxt.SetActive(false);
        UITOP.transform.GetChild(1).gameObject.SetActive(true);
        UITOP.transform.GetChild(0).GetComponent<RawImage>().texture = antexture;
    }
    public void BackToMenu()
    {
        pano.gameObject.SetActive(false);
        Destroy(transform.GetChild(0).gameObject);
        mainpanel.offsetMax = Vector2.zero;
        mainpanel.offsetMin = Vector2.zero;
        UITOP.transform.GetChild(2).gameObject.SetActive(true);
        UITOP.gameObject.SetActive(false);
        butonMM.SetActive(true);
        niveaux.GetChild(niveaux.childCount - 1).gameObject.SetActive(false);
        niveaux.GetChild(niveaux.childCount - 3).gameObject.SetActive(false);
        niveaux.GetChild(niveaux.childCount - 2).gameObject.SetActive(false);
        niveaux.GetChild(niveaux.childCount - 1).gameObject.SetActive(false);
        ResetPages();
        errortxt.SetActive(false);
        InMenu = true;
        feuilles.SetActive(true);
    }
    public void printtest()
    {
    }
    public void OpenLevel(int lvl)
    {
        if (lvl <= save.ReadGo())
        {
            niveaux.gameObject.SetActive(false);
            currentlvl = lvl;
            lvlman.SpawnLevel(lvl);
            UITOP.SetActive(true);
            butonMM.SetActive(false);
            InMenu = false;
            LvlTxt.text = "Niveau " + (currentlvl + 1).ToString();
            feuilles.SetActive(false);
            Reset();
        }
    }


    public void NextLvl()
    {
        if (currentlvl==31&& save.ReadGo() >= 32)
        {
            BackToMenu();
        }
        else {
            lvlman.Clean();
            currentlvl += 1;
            lvlman.SpawnLevel(currentlvl);
            LvlTxt.text = "Niveau " + (currentlvl + 1).ToString();
            pano.gameObject.SetActive(false);
            feuilles.SetActive(false);
            Reset();
        }
    }

    public void OnPlayClick()
    {
        if (forcelvl)
        {
            feuilles.SetActive(false);
            niveaux.gameObject.SetActive(false);
            lvlman.SpawnLevel(currentlvl);
            UITOP.SetActive(true);
            butonMM.SetActive(false);
            InMenu = false;
            LvlTxt.text = "Niveau " + (currentlvl + 1).ToString();
            Reset();
        }
        else {
            int m = save.ReadGo();
            if (m >= 32)
                m = Random.Range(0, 32);
            OpenLevel(m);

        }
        
    }
    public void OnClickQuit()
    {
        Application.Quit();
        
    }
    public void GetLinkOwnApp()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Luka.Panda");
       
    }
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (InMenu)
                Application.Quit();
        }
    }
     public void GoodAnswert()
    {
        //parts.GoEmit();
        HM.OnLevelFinish();
        if (currentlvl == 31&& save.ReadGo()==31)
        {
            feuilles.GetComponent<FeuilleSpawner>().normal = false;
            BackToMenu();
            anim.enabled = true;
        }
        else { pano.gameObject.SetActive(true); }
       
        save.SaveGo(currentlvl + 1);
       
        
    }
    public void Redirection(string s)
    {
        transform.GetChild(0).GetComponent<WrittenAnswer>().Test(s);
    }
    public void NoAnswer()
    {
        UITOP.transform.GetChild(1).gameObject.SetActive(false);
        UITOP.transform.GetChild(0).GetComponent<RawImage>().texture = noantexture;
    }
    public void OnClickLvl()
    {
        StartCoroutine(GoDownLvl());

    }
    public void OnclickSwitchLvl()
    {
        if (save.ReadGo()>15) {
            if (isleft)
            {
                Colorballs2();
                StartCoroutine(NextPage());
                isleft = false;
            }
            else
            {
                StartCoroutine(PreviousPage());
                isleft = true;
            }
        }

    }
    

    public void OnAbout()
    {
        StartCoroutine(OpenAbout());
    }
    public void OnCloseAbout()
    {
        StartCoroutine(CloseAbout());
    }
    IEnumerator OpenAbout()
    {
        aboutpan.gameObject.SetActive(true);
        float i = 0;
        Vector2 start = new Vector2(-1080, 0);
        Vector2 end = Vector2.zero;
        while (i < 1)
        {
            Vector2 k = Vector2.Lerp(start, end, Mathf.SmoothStep(0, 1, i));
            aboutpan.offsetMax = k;
            aboutpan.offsetMin = k;
            i += Time.deltaTime*2;
            yield return null;
        }
        aboutpan.offsetMin = end;
        aboutpan.offsetMax = end;

    }
    IEnumerator CloseAbout()
    {

        float i = 0;
        Vector2 start = new Vector2(-1080, 0);
        Vector2 end = Vector2.zero;
        while (i < 1)
        {
            Vector2 k = Vector2.Lerp(end,start, Mathf.SmoothStep(0, 1, i));
            aboutpan.offsetMax = k;
            aboutpan.offsetMin = k;
            i += Time.deltaTime * 2;
            yield return null;
        }
        aboutpan.offsetMin = end;
        aboutpan.offsetMax = end;
        aboutpan.gameObject.SetActive(false);
    }

    void ResetPages()
    {
        Vector2 right = new Vector2(1080, 0);
        RectTransform fleche = niveaux.GetChild(niveaux.childCount - 2).GetComponent<RectTransform>();
        RectTransform page1 = niveaux.GetChild(0).GetComponent<RectTransform>();
        RectTransform page2 = niveaux.GetChild(1).GetComponent<RectTransform>();
        page2.offsetMin = right;
        page2.offsetMax = right;
        page1.offsetMax = Vector2.zero;
        page1.offsetMin = Vector2.zero;
        fleche.eulerAngles = new Vector3(0, 0, 90);
        isleft = true;
    }
    IEnumerator NextPage()
    {
        float i = 0;
        Vector2 left = new Vector2(-1080, 0);
        Vector2 right = new Vector2(1080, 0);
        RectTransform fleche =niveaux.GetChild(niveaux.childCount - 2).GetComponent<RectTransform>();
        RectTransform page1 = niveaux.GetChild(0).GetComponent<RectTransform>();
        RectTransform page2 = niveaux.GetChild(1).GetComponent<RectTransform>();
        while (i < 1)
        {
            float z = Mathf.SmoothStep(0, 1, i);
            Vector2 k = Vector2.Lerp(Vector2.zero, left, z);
            Vector2 k2 = Vector2.Lerp(right, Vector2.zero, z);
            float ang = Mathf.Lerp(90, 270, z);
            page1.offsetMax = k;
            page1.offsetMin = k;
            page2.offsetMin = k2;
            page2.offsetMax = k2;
            fleche.eulerAngles = new Vector3(0, 0, ang);
            i += Time.deltaTime*1.25f;
            yield return null;
        }
        page2.offsetMin = Vector2.zero ;
        page2.offsetMax = Vector2.zero;
        page1.offsetMax = left;
        page1.offsetMin = left;
        fleche.eulerAngles = new Vector3(0, 0, 270);
     
    }
    IEnumerator PreviousPage()
    {
        float i = 0;
        Vector2 left = new Vector2(-1080, 0);
        Vector2 right = new Vector2(1080, 0);
        RectTransform fleche = niveaux.GetChild(niveaux.childCount - 2).GetComponent<RectTransform>();
        RectTransform page1 = niveaux.GetChild(0).GetComponent<RectTransform>();
        RectTransform page2 = niveaux.GetChild(1).GetComponent<RectTransform>();
        while (i < 1)
        {
            float z = Mathf.SmoothStep(0, 1, i);
            Vector2 k = Vector2.Lerp(left, Vector2.zero, z);
            Vector2 k2 = Vector2.Lerp(Vector2.zero, right, z);
            float ang = Mathf.Lerp(270, 90, z);
            page1.offsetMax = k;
            page1.offsetMin = k;
            page2.offsetMin = k2;
            page2.offsetMax = k2;
            fleche.eulerAngles = new Vector3(0, 0, ang);
            i += Time.deltaTime * 1.25f;
            yield return null;
        }
        page2.offsetMin = right;
        page2.offsetMax = right;
        page1.offsetMax = Vector2.zero;
        page1.offsetMin = Vector2.zero;
        fleche.eulerAngles = new Vector3(0, 0, 90);
    }
    IEnumerator GoDownLvl()
    {
        float i = 0;
        while(i<1)
        {
            Vector2 k = Vector2.Lerp(Vector2.zero, bottom, Mathf.SmoothStep(0,1,i));
            mainpanel.offsetMax = k;
            mainpanel.offsetMin = k;
            
            i += Time.deltaTime*2;
            yield return null;
        }
        mainpanel.offsetMin = bottom;
        mainpanel.offsetMax = bottom;
        Colorballs();
        StartCoroutine(GoBalls());
    }
    public void OnclickGoUp()
    {
        StartCoroutine(GoUpLvl());
        
    }
    IEnumerator GoUpLvl()
    {
        float i = 0;
        while (i < 1)
        {
            Vector2 k = Vector2.Lerp(bottom, Vector2.zero, Mathf.SmoothStep(0, 1, i));
            Vector2 k2 = Vector2.Lerp(Vector2.zero,bottom , Mathf.SmoothStep(0, 1, i));
            mainpanel.offsetMax = k;
            mainpanel.offsetMin = k;
            niveaux.offsetMax = -k2;
            niveaux.offsetMin = -k2;

            i += Time.deltaTime * 2;
            yield return null;
        }
        mainpanel.offsetMin = Vector2.zero;
        mainpanel.offsetMin = Vector2.zero;
        niveaux.gameObject.SetActive(false);
        niveaux.offsetMax = Vector2.zero;
        niveaux.offsetMin = Vector2.zero;
        niveaux.GetChild(niveaux.childCount - 3).gameObject.SetActive(false);
        niveaux.GetChild(niveaux.childCount - 2).gameObject.SetActive(false);
        niveaux.GetChild(niveaux.childCount - 1).gameObject.SetActive(false);
        ResetPages();
    }
    void Colorballs()
    {
        Transform niveauxreal = niveaux.GetChild(0);
        int num = save.ReadGo() + 1;
        if (num > 32)
            num = 32;
        int num2 = 0;
        if (num > 16)
        {
            niveaux.GetChild(niveaux.childCount - 2).GetComponent<RawImage>().texture = goldenarrow;
            num2 = num - 16;
            num = 16;
        }
        for (int i = 0; i< num; i++)
        {
            niveauxreal.GetChild(i).GetChild(0).GetComponent<RawImage>().color = Color.white;
        }
        niveauxreal = niveaux.GetChild(1);
        for (int i = 0; i < num2; i++)
        {
            niveauxreal.GetChild(i).GetChild(0).GetComponent<RawImage>().color = Color.white;
        }
    }
    void Colorballs2()
    {
        Transform niveauxreal = niveaux.GetChild(1);
        int svgo = save.ReadGo();
        if (svgo > 31)
            svgo = 31;
        for (int i = 0; i < svgo-15; i++)
        {
            niveauxreal.GetChild(i).GetChild(0).GetComponent<RawImage>().color = Color.white;
        }
    }
    IEnumerator GoBalls()
    {
        Transform niveauxreal = niveaux.GetChild(0);
        float i = 0;
        niveaux.gameObject.SetActive(true);
        RectTransform[] k = new RectTransform[16];
        int child = niveauxreal.childCount - 1;
        
        while (i < 1)
        {
            for (int z = 0; z < child+1; z++)
            {
                if(i==0)
                {
                    k[z] = niveauxreal.GetChild(child-z).GetComponent<RectTransform>();
                }
                
                k[z].localScale = Vector2.Lerp(Vector2.zero, Vector2.one, (i * 2) -((float)z / 16));
            }
            i += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(ColorLvl());
    }
    IEnumerator ColorLvl()
    {
        niveaux.GetChild(niveaux.childCount - 3).gameObject.SetActive(true);
        niveaux.GetChild(niveaux.childCount - 2).gameObject.SetActive(true);
        niveaux.GetChild(niveaux.childCount - 1).gameObject.SetActive(true);
        RawImage wo = niveaux.GetChild(niveaux.childCount - 1).GetComponent<RawImage>();
        RawImage wo2 = niveaux.GetChild(niveaux.childCount - 2).GetComponent<RawImage>();
        RawImage wo3 = niveaux.GetChild(niveaux.childCount - 3).GetComponent<RawImage>();
        Color a = new Color(1, 1, 1, 0);
        Color b = new Color(1, 1, 1, 1);
        float d = 0;
        while (d < 1)
        {
            d += Time.deltaTime;
            wo.color = Color.Lerp(a, b, d);
            wo2.color = Color.Lerp(a, b, d);
            wo3.color = Color.Lerp(a, b, d);
            yield return null;
        }
        wo.color = b;
        wo2.color = b;
        wo3.color = b;
    }

}

