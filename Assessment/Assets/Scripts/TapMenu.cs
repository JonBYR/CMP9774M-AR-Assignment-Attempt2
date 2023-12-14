using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapMenu : MonoBehaviour
{
    public GameObject menuToEnable;
    // Start is called before the first frame update
    public void EnableMenu()
    {
        menuToEnable.SetActive(true);
        Invoke("DisableMenu", 2f);
    }
    void DisableMenu()
    {
        menuToEnable.SetActive(false);
    }
}
