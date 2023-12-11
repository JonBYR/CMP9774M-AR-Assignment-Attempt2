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
    public GameObject planeOnboarding;
    public GameObject planeText;
    List<GameObject> TrophyList = new List<GameObject>();
    public ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public int markersFound = 0;
    //[SerializeField] private Button trophyButton;
    public GameObject findText;
    [SerializeField] private Button displayButton;
    // Start is called before the first frame update
    void Start()
    {
        planeOnboarding.SetActive(false);
        planeText.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                return;
            }
            if (touch.phase == TouchPhase.Began)
            {
                var touchPosition = touch.position;
                Ray ray = Camera.main.ScreenPointToRay(touchPosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Trophy"))
                {
                    Destroy(hit.transform.gameObject); 
                }
                else if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
                {
                    var hitPose = hits[0].pose;
                    switch (markersFound)
                    {
                        case 0:
                            if (findText != null)
                            {
                                Debug.Log("FindText active");
                                findText.SetActive(true);
                                Invoke("removeText", 2f);
                            }
                            return;
                        case 1:
                            if (Bronze != null)
                            {
                               var BT = Instantiate(Bronze, hitPose.position, hitPose.rotation);
                                TrophyList.Add(BT);
                            }
                            break;
                        case 2:
                            if (Silver != null)
                            {
                                var ST = Instantiate(Silver, hitPose.position, hitPose.rotation);
                                TrophyList.Add(ST);
                            }
                            break;
                        case 3:
                            if (Gold != null)
                            {
                                var GT = Instantiate(Gold, hitPose.position, hitPose.rotation);
                                TrophyList.Add(GT);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

    }
    void removeText()
    {
        findText.SetActive(false);
    }
    public void RemoveTrophy()
    {
        Debug.Log("Button Called");
        if(TrophyList.Count == 0) 
        {
            Debug.Log("Button Returned");
            return;
        }
        else
        {
            foreach(var item in TrophyList) 
            { 
                Destroy(item);
            }
            TrophyList.Clear();
        }
    }
    public void DisplayOnboarding()
    {
        planeOnboarding.SetActive(true);
        planeText.SetActive(true);
        Invoke("OffBoarding", 2f);
    }
    void OffBoarding()
    {
        planeOnboarding.SetActive(false);
        planeText.SetActive(false);
    }
}
