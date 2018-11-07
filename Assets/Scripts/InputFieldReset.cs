using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputFieldReset : MonoBehaviour {

	public void InputReset()
    {
        GetComponent<InputField>().text = "";
    }
}
