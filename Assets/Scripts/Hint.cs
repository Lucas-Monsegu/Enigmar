using UnityEngine;
using System.Collections;

public class Hint : MonoBehaviour {
    public bool English;

    [SerializeField]
    private string[] FR = new string[3] {
     ""
    ,""
    ,""};
    [SerializeField]
    private string[] EN = new string[3] {
     ""
    ,""
    ,""};
    public string[] tab { get {
            if (English)
                return EN;
            else
                return FR;
        } }
}
