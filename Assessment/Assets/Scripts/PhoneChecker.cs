using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PhoneChecker : MonoBehaviour
{
    GameObject objectImage;
    GameObject objectText;
    public XROrigin session;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
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
        Ray ray = Camera.main.ScreenPointToRay(session.transform.position);
    }
}
