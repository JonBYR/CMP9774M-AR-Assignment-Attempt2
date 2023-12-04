using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
public class TreasureFound : MonoBehaviour
{
    private GameObject treasureImage;
    private GameObject treasureText;
    public static bool cathedralFound = false;
    public static bool footballFound = false;
    public static bool universityFound = false;
    private DisplayTrophy d;
    public AudioSource clip;
    public GameObject foundText;
    private Button closeButton;
    private void Start()
    {
        d = GameObject.Find("ButtonController").GetComponent<DisplayTrophy>();
        if(this.gameObject.tag == "Angel")
        {
            treasureText = GameObject.Find("CathedralContainer");
            treasureText.transform.GetChild(1).gameObject.SetActive(true);
            closeButton = treasureText.transform.GetChild(1).gameObject.GetComponent<Button>();
            closeButton.onClick.AddListener(() => RemoveFromScene());
            if (!cathedralFound) 
            { 
                treasureImage = GameObject.Find("CathedralTreasure");
                treasureImage.SetActive(false);
                cathedralFound = true;
                clip.Play();
                Handheld.Vibrate();
                d.markersFound++;
            }
            else
            {
                Instantiate(foundText, foundText.transform.position, foundText.transform.rotation);
                Invoke("DestroyText", 2.0f);
            }
            treasureText.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(this.gameObject.tag == "Football")
        {
            treasureText = GameObject.Find("FootballContainer");
            treasureText.transform.GetChild(1).gameObject.SetActive(true);
            closeButton = treasureText.transform.GetChild(1).gameObject.GetComponent<Button>();
            closeButton.onClick.AddListener(() => RemoveFromScene());
            if (!footballFound)
            {
                treasureImage = GameObject.Find("FootballTreasure");
                treasureImage.SetActive(false);

                footballFound = true;
                clip.Play();
                Handheld.Vibrate();
                d.markersFound++;
            }
            else
            {
                Instantiate(foundText, foundText.transform.position, foundText.transform.rotation);
                Invoke("DestroyText", 2.0f);
            }
            treasureText.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(this.gameObject.tag == "Laptop")
        {
            treasureText = GameObject.Find("UniversityContainer");
            treasureText.transform.GetChild(1).gameObject.SetActive(true);
            closeButton = treasureText.transform.GetChild(1).gameObject.GetComponent<Button>();
            closeButton.onClick.AddListener(() => RemoveFromScene());
            if (!universityFound)
            {
                treasureImage = GameObject.Find("UniversityTreasure");
                treasureImage.SetActive(false);
                universityFound = true;
                clip.Play();
                Handheld.Vibrate();
                d.markersFound++;
            }
            else
            {
                Instantiate(foundText, foundText.transform.position, foundText.transform.rotation);
                Invoke("DestroyText", 2.0f);
            }
            treasureText.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void RemoveFromScene() //should be called when game object is destroyed
    {
        treasureText.transform.GetChild(0).gameObject.SetActive(false);
        treasureText.transform.GetChild(1).gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
    void DestroyText()
    {
        Destroy(foundText);
    }
}
