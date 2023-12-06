using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneChecker : MonoBehaviour
{
    GameObject objectImage;
    GameObject objectText;
    LocationInfo info;
    // Start is called before the first frame update

    private void Start()
    {
        objectImage =GameObject.Find("DisplayObject");
        objectText = GameObject.Find("ObjectText");
        objectImage.SetActive(false);
        objectImage.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Device Altitiude-> " + info.altitude);
        /*
        if(info.altitude <= 0)
        {
            objectImage.SetActive(true);
            objectImage.SetActive(true);
        }
        else
        {
            objectImage.SetActive(false);
            objectImage.SetActive(false);
        }
        */
    }
}
