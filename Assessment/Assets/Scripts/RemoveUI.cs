using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveUI : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine("UIRemoval");
    }

    // Update is called once per frame
    IEnumerator UIRemoval()
    {
        yield return new WaitForSeconds(5f);
        this.gameObject.SetActive(false);
    }
}
