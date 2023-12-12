using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PhoneChecker : MonoBehaviour
{
    GameObject objectImage;
    GameObject objectText;
    //public XROrigin session;
    public ARPlane plane;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private DisplayTrophy d;
    // Start is called before the first frame update

    private void Start()
    {
        objectImage =GameObject.Find("DisplayObject");
        objectText = GameObject.Find("ObjectText");
        objectImage.SetActive(false);
        objectImage.SetActive(false);
        d = GameObject.Find("ButtonController").GetComponent<DisplayTrophy>();
    }
    // Update is called once per frame
    void Update()
    {
        if (d.markersFound == 0) return;
        else
        {
            float dist = Vector3.Distance(Camera.main.transform.position, plane.transform.position);
            if (dist < 0.5)
            {
                Reminder();
            }
            else return;
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
    }
}
