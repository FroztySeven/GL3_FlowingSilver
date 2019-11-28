using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject MainAll;
    public GameObject PlayLoadingCanvas;

    AsyncOperation async;
    //public Slider LoadingSlider;

    // Start is called before the first frame update
    void Start()
    {
        MainCanvas.SetActive(true);
        MainAll.SetActive(true);
        PlayLoadingCanvas.SetActive(false);
    }

    IEnumerator LoadTutorialAsync()
    {
        MainAll.SetActive(false);
        PlayLoadingCanvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        yield return new WaitForSeconds(0.5f);
        PlayLoadingCanvas.SetActive(true);

        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;


        while (async.isDone == false)
        {
            //LoadingSlider.value = async.progress;
            if (async.progress == 0.9f)
            {
                //LoadingSlider.value = 1f;
                async.allowSceneActivation = true;
                StopAllCoroutines();
            }
            yield return null;
        }
    }



    // Main menu functionality
    public void OnClickPlay()
    {
        Tutorial_01.beenToLevel = false;
        StartCoroutine("LoadTutorialAsync", 1f);
    }

    public void OnClickCredits()
    {

    }

    public void OnClickQuit()
    {
        print("User quit the game!");
        Application.Quit();
    }


}
