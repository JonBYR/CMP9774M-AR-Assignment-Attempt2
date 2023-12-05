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
        //footballButton.onClick.AddListener(() => RemoveFootballContainer());
        //laptopButton.onClick.AddListener(() => RemoveLaptopContainer());
        //cathedralButton.onClick.AddListener(() => RemoveCathedralContainer());
    }
    private void Update()
    {
        if (footballSpawned)
        {
            footballContainer.SetActive(true);
        }
        else if(laptopSpawned)
        {
            laptopContainer.SetActive(true);
        }
        else if(cathedralSpawned)
        {
            cathedralContainer.SetActive(true);
        }
    }

    public void RemoveFootballContainer()
    {
        Debug.Log("Football Container Removed");
        footballSpawned = false;
        Debug.Log(footballSpawned);
        footballContainer.SetActive(false);
        foreach (var gb in prefabImagePairManager.m_Instantiated)
        {
            if (gb.Value.gameObject.tag.Equals("Football"))
            {
                Destroy(gb.Value.gameObject);
            }
        }
    }
    public void RemoveLaptopContainer()
    {
        Debug.Log("Laptop Container Removed");
        laptopSpawned = false;
        Debug.Log(laptopSpawned);
        laptopContainer.SetActive(false);
        foreach (var gb in prefabImagePairManager.m_Instantiated)
        {
            if (gb.Value.gameObject.tag.Equals("Laptop"))
            {
                Destroy(gb.Value.gameObject);
            }
        }
    }
    public void RemoveCathedralContainer()
    {
        Debug.Log("Cathedral Container Removed");
        cathedralSpawned = false;
        Debug.Log(cathedralSpawned);
        cathedralContainer.SetActive(false);
        foreach (var gb in prefabImagePairManager.m_Instantiated)
        {
            if (gb.Value.gameObject.tag.Equals("Angel"))
            {
                Destroy(gb.Value.gameObject);
            }
        }
    }
}
