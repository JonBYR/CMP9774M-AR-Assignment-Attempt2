using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using TMPro;
public class DisplayTrophy : MonoBehaviour
{
    public GameObject Bronze;
    public GameObject Silver;
    public GameObject Gold;
    private bool bronzeDisplay;
    private bool silverDisplay;
    private bool goldDisplay;
    private bool canDisplay = false;
    private ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public int markersFound = 0;
    //[SerializeField] private Button trophyButton;
    private GameObject findText;
    public ARPlane plane;
    [SerializeField] private Button displayButton;
    //private GameObject tapInstructions;
    // Start is called before the first frame update
    void Awake()
    {
        findText = GameObject.Find("FindText");
        findText.SetActive(false);
        arRaycastManager = GetComponent<ARRaycastManager>();
        canDisplay = false;
        plane.enabled = false;
        displayButton.onClick.AddListener(() => currentPrefab(markersFound));
    }

    // Update is called once per frame
    public void OnButtonTouch()
    {
        if (markersFound == 0) 
        {
            Debug.Log("Called");
            findText.SetActive(true);
            Invoke("removeText", 2f);
            return; 
        }
        else
        {
            canDisplay = true;
        }
        //tapInstructions.SetActive(false);
    }
    private void Update()
    {
        if (canDisplay == true)
        {
            plane.enabled = true;
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId)) return;
                if(touch.phase == TouchPhase.Began)
                {
                    var touchPosition = touch.position;
                    Ray ray = Camera.main.ScreenPointToRay(touchPosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Trophy")) Destroy(hit.transform.gameObject);
                    else if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
                    {
                        var hitPose = hits[0].pose;
                        if (bronzeDisplay) Instantiate(Bronze, hitPose.position, hitPose.rotation);
                        if (silverDisplay) Instantiate(Silver, hitPose.position, hitPose.rotation);
                        if (goldDisplay) Instantiate(Gold, hitPose.position, hitPose.rotation);
                    }
                }
            }
        }
        /*
        else if (canDisplay == false)
        {
            plane.enabled = false;
            RemoveTrophy();
        }
        */
    }
    public void currentPrefab(int m)
    {
        if (m == 0) 
        {
            
        }
        else if (m == 1)
        {
            bronzeDisplay = true;
            silverDisplay = false;
            goldDisplay = false;
        }
        else if (m == 2)
        {
            bronzeDisplay = false;
            silverDisplay = true;
            goldDisplay = false;
        }
        else if (m == 3)
        {
            bronzeDisplay = false;
            silverDisplay = false;
            goldDisplay = true;
        }
    }
    void removeText()
    {
        findText.SetActive(false);
    }
    void RemoveTrophy()
    {
        if (bronzeDisplay) Destroy(Bronze);
        if (silverDisplay) Destroy(Silver);
        if (goldDisplay) Destroy(Gold);
    }
}
