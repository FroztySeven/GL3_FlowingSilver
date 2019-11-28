using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SkipCutscene : MonoBehaviour
{
    public VideoPlayer vp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vp.isPaused || Input.GetKeyDown("t"))
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

}
