using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation.samples;

public class ARManager : MonoBehaviour
{
    public GameObject cathedralImage;
    public GameObject laptopImage;
    public GameObject footballImage;
    public GameObject cathedralContainer;
    public GameObject laptopContainer;
    public GameObject footballContainer;
    public bool footballSpawned;
    public bool laptopSpawned;
    public bool cathedralSpawned;
    public Button cathedralButton;
    public Button laptopButton;
    public Button footballButton;
    public PrefabImagePairManager prefabImagePairManager;
    public static ARManager instance;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this); //already have one in scene
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        footballSpawned = false;
        laptopSpawned = false;
        cathedralSpawned = false;
    }
    private void Update()
    {
        if (footballSpawned)
        {
            footballContainer.SetActive(true);
            footballSpawned=false;
        }
        else if(laptopSpawned)
        {
            laptopContainer.SetActive(true);
            laptopSpawned=false;
        }
        else if(cathedralSpawned)
        {
            cathedralContainer.SetActive(true);
            cathedralSpawned=false;
        }
    }
}
