using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RotatePrefab : MonoBehaviour
{
    private GameObject prefab;
    private bool canRotate;
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
    private Camera mainCamera;
    private ARRaycastManager raycastManager;
    // Start is called before the first frame update
    void Start()
    {
        canRotate = true;
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        raycastManager = GameObject.Find("XR Origin").GetComponent<ARRaycastManager>();
    }
    private void OnEnable()
    {
        transform.LookAt(mainCamera.transform);
        transform.Rotate(0, -180, 0); //this technique is called billboarding
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 0)
        {
            var touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = mainCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.tag == this.gameObject.tag) canRotate = !canRotate;
                }
            }
        }
        if (canRotate) 
        {
            this.transform.RotateAround(this.transform.position, Vector3.up, 50 * Time.deltaTime); 
        }
    }
}
