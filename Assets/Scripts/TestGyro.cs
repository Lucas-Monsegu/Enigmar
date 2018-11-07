using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestGyro : MonoBehaviour
{
    [SerializeField]
    Text tx;
    [SerializeField]
    Transform tf;
    // Use this for initialization
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
            Input.gyro.enabled = true;
        else
        {
            transform.parent.GetComponent<MainMenu>().ErrorLevel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //tx.text = Input.gyro.attitude.ToString();
        tf.rotation = Input.gyro.attitude;
    }
}
