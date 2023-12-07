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
    List<GameObject> TrophyList = new List<GameObject>();
    private ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public int markersFound = 0;
    //[SerializeField] private Button trophyButton;
    public GameObject findText;
    [SerializeField] private Button displayButton;
    bool _turnOnPlane;
    //public ARPlane plane;
    // Start is called before the first frame update
    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        _turnOnPlane = false;
        //plane.enabled = true;
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
                                Instantiate(Bronze, hitPose.position, hitPose.rotation);
                                TrophyList.Add(Bronze);
                            }
                            break;
                        case 2:
                            if (Silver != null)
                            {
                                Instantiate(Silver, hitPose.position, hitPose.rotation);
                                TrophyList.Add(Silver);
                            }
                            break;
                        case 3:
                            if (Gold != null)
                            {
                                Instantiate(Gold, hitPose.position, hitPose.rotation);
                                TrophyList.Add(Gold);
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
        for(int i = 0; i< TrophyList.Count; i++)
        {
            Destroy(TrophyList[i]);
        }
        TrophyList.Clear();
    }
}
