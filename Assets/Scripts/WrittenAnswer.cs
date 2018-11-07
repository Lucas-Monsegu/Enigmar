using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WrittenAnswer : MonoBehaviour {

    public string[] answers;

    public bool NumbersOnly;
    void Start()
    {
        if (NumbersOnly)
        {

            GameObject j = GameObject.FindGameObjectWithTag("UITOP");
            if(j!=null)
                j.GetComponent<InputField>().contentType = InputField.ContentType.IntegerNumber;
        }
        else
        {
            GameObject j = GameObject.FindGameObjectWithTag("UITOP");
            if (j != null)
                j.GetComponent<InputField>().contentType = InputField.ContentType.Alphanumeric;
        }
    }
    virtual public void Test(string s)
    {
        bool b = false;
        foreach(string rep in answers)
        {
            if (s == rep)
                b = true;
        }
        if(b)
        {
            transform.parent.GetComponent<MainMenu>().GoodAnswert();
        }
    }
}
