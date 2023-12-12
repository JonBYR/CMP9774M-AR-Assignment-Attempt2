using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Onboarding : MonoBehaviour
{
    private GameObject onboard;
    private GameObject text;
    private float timer = 2.5f;
    public PhoneChecker check;
    // Start is called before the first frame update
    void Start()
    {
        check.enabled = false;
        onboard = GameObject.Find("DisplayObject");
        text = GameObject.Find("ObjectText");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            onboard.SetActive(false);
            text.SetActive(false);
            check.enabled = true;
        }
    }
}
