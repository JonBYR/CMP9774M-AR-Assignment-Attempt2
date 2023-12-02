using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
public class TreasureFound : MonoBehaviour
{
    private Image treasureImage;
    private GameObject treasureText;
    public static bool cathedralFound = false;
    public static bool footballFound = false;
    public static bool universityFound = false;
    private DisplayTrophy d;
    public AudioSource clip;
    public GameObject foundText;
    private void Awake()
    {
        if(this.gameObject.name == "angelStatue")
        {
            treasureText = GameObject.Find("CathedralContainer");
            if (!cathedralFound) 
            { 
                treasureImage = GameObject.Find("CathedralTreasure").GetComponent<Image>();
                cathedralFound = true;
                Destroy(treasureImage);
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
        else if(this.gameObject.name == "SoccerBall_01")
        {
            treasureText = GameObject.Find("FootballContainer");
            if(!footballFound)
            {
                treasureImage = GameObject.Find("FootballTreasure").GetComponent<Image>();
                footballFound = true;
                Destroy(treasureImage);
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
        else if(this.gameObject.name == "Laptop_white")
        {
            treasureText = GameObject.Find("UniversityContainer");
            if (!universityFound)
            {
                treasureImage = GameObject.Find("UniversityTreasure").GetComponent<Image>();
                universityFound = true;
                Destroy(treasureImage);
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
    private void OnDestroy() //should be called when game object is destroyed
    {
        treasureText.transform.GetChild(0).gameObject.SetActive(false);
    }
    void DestroyText()
    {
        Destroy(foundText);
    }
}
