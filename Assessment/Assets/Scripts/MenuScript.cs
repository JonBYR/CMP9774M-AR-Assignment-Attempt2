using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if ((currentScene.buildIndex == 1)) //if we are currently on the last scene
        {
            Debug.Log("Loading main menu");
            StartCoroutine(CreateScene(0));
        }
        else
        {
            StartCoroutine(CreateScene(1));
        }
    }
    IEnumerator CreateScene(int index) //loads scene in the background
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(index);
        op.allowSceneActivation = false;
        float timer = 0f;
        while(timer <= 2f)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        op.allowSceneActivation = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
