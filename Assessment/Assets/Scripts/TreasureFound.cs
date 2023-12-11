using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
public class TreasureFound : MonoBehaviour
{
    public static bool cathedralFound = false;
    public static bool footballFound = false;
    public static bool universityFound = false;
    private DisplayTrophy d;
    public AudioSource clip;
    public GameObject foundText;
    private void Start()
    {
        d = GameObject.Find("ButtonController").GetComponent<DisplayTrophy>();
        if(this.gameObject.tag == "Angel")
        {
            ARManager.instance.cathedralSpawned = true;
            /*arManager.cathedralContainer.transform.GetChild(1).gameObject.SetActive(true);
            arManager.cathedralButton = arManager.cathedralButton.transform.GetChild(1).gameObject.GetComponent<Button>();
            arManager.cathedralButton.onClick.AddListener(() => RemoveFromScene());
            arManager.cathedralContainer.transform.GetChild(0).gameObject.SetActive(true);*/
            if (!cathedralFound) 
            {
                ARManager.instance.cathedralImage.SetActive(false);
                cathedralFound = true;
                clip.Play();
                Handheld.Vibrate();
                d.markersFound++;
                d.DisplayOnboarding();
            }
            else
            {
                Instantiate(foundText, foundText.transform.position, foundText.transform.rotation);
                Invoke("DestroyText", 2.0f);
            }
        }
        else if(this.gameObject.tag == "Football")
        {
            ARManager.instance.footballSpawned = true;
            /*treasureText = GameObject.Find("FootballContainer");
            treasureText.transform.GetChild(1).gameObject.SetActive(true);
            closeButton = treasureText.transform.GetChild(1).gameObject.GetComponent<Button>();*/
            //closeButton.onClick.AddListener(() => RemoveFromScene());
            if (!footballFound)
            {

                ARManager.instance.footballImage.SetActive(false);

                footballFound = true;
                clip.Play();
                Handheld.Vibrate();
                d.markersFound++;
                d.DisplayOnboarding();
            }
            else
            {
                Instantiate(foundText, foundText.transform.position, foundText.transform.rotation);
                Invoke("DestroyText", 2.0f);
            }
            //treasureText.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(this.gameObject.tag == "Laptop")
        {
            ARManager.instance.laptopSpawned = true;
            /*treasureText = GameObject.Find("UniversityContainer");
            treasureText.transform.GetChild(1).gameObject.SetActive(true);
            closeButton = treasureText.transform.GetChild(1).gameObject.GetComponent<Button>();
            closeButton.onClick.AddListener(() => RemoveFromScene());*/
            if (!universityFound)
            {

                ARManager.instance.laptopImage.SetActive(false);
                universityFound = true;
                clip.Play();
                Handheld.Vibrate();
                d.markersFound++;
                d.DisplayOnboarding();
            }
            else
            {
                Instantiate(foundText, foundText.transform.position, foundText.transform.rotation);
                Invoke("DestroyText", 2.0f);
            }
            //treasureText.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    /*private void RemoveFromScene() //should be called when game object is destroyed
    {
        treasureText.transform.GetChild(0).gameObject.SetActive(false);
        treasureText.transform.GetChild(1).gameObject.SetActive(false);
        Destroy(this.gameObject);
    }*/
    void DestroyText()
    {
        Destroy(foundText);
    }
}
