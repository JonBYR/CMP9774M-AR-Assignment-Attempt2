using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PhoneChecker : MonoBehaviour
{
    public GameObject objectImage;
    public GameObject objectText;
    //public XROrigin session;
    public ARPlane plane;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private DisplayTrophy d;
    public float timer;
    // Start is called before the first frame update

    private void Start()
    {
        timer = 0;
        d = GameObject.Find("ButtonController").GetComponent<DisplayTrophy>();
    }
    // Update is called once per frame
    void Update()
    {
        if (d.markersFound == 0 || d.markersFound == 3) return;
        else
        {
            timer += Time.deltaTime;
            if(timer >= 30f)
            {
                Reminder();
            }
        }
    }
    void Reminder()
    {
        objectImage.SetActive(true);
        objectText.SetActive(true);
        Invoke("RemoveOnboarding", 2f);
    }
    void RemoveOnboarding()
    {
        objectImage.SetActive(false);
        objectImage.SetActive(false);
        timer = 0;
    }
}
