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
    //private GameObject tapInstructions;
    // Start is called before the first frame update
    void Awake()
    {
        findText = GameObject.Find("FindText");
        findText.SetActive(false);
        arRaycastManager = GetComponent<ARRaycastManager>();
        canDisplay = false;
        plane.enabled = false;
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
            canDisplay = !canDisplay;
            if(canDisplay == true)
            {
                plane.enabled = true;
                currentPrefab(markersFound);
                if (bronzeDisplay) Instantiate(Bronze, plane.transform.position + new Vector3(20f, 1f, 20f), plane.transform.rotation);
                if (silverDisplay) Instantiate(Silver, plane.transform.position + new Vector3(20f, 1f, 20f), plane.transform.rotation);
                if (goldDisplay) Instantiate(Gold, plane.transform.position + new Vector3(20f, 1f, 20f), plane.transform.rotation);
            }
            else if(plane.enabled == false)
            {
                plane.enabled = false;
                RemoveTrophy();
            }
        }
        //tapInstructions.SetActive(false);
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
