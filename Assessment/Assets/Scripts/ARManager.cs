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
    private void Start()
    {
        footballSpawned = false;
        laptopSpawned = false;
        cathedralSpawned = false;
        footballButton.onClick.AddListener(() => RemoveFootballContainer());
        laptopButton.onClick.AddListener(() => RemoveLaptopContainer());
        cathedralButton.onClick.AddListener(() => RemoveCathedralContainer());
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

    void RemoveFootballContainer()
    {
        footballSpawned = false;
        foreach(var gb in prefabImagePairManager.m_Instantiated)
        {
            if (gb.Value.gameObject.tag.Equals("Football"))
            {
                Destroy(gb.Value.gameObject);
            }
        }
    }
    void RemoveLaptopContainer()
    {
        laptopSpawned = false;
        foreach (var gb in prefabImagePairManager.m_Instantiated)
        {
            if (gb.Value.gameObject.tag.Equals("Laptop"))
            {
                Destroy(gb.Value.gameObject);
            }
        }
    }
    void RemoveCathedralContainer()
    {
        cathedralSpawned = false;
        foreach (var gb in prefabImagePairManager.m_Instantiated)
        {
            if (gb.Value.gameObject.tag.Equals("Angel"))
            {
                Destroy(gb.Value.gameObject);
            }
        }
    }
}
