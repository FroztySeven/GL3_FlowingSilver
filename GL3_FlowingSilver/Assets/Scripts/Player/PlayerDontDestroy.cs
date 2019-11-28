using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1)
        {
            Destroy(gameObject);
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();


        string sceneName = currentScene.name;
        if (sceneName == "Menu")
        {
            Destroy(gameObject);
        }
        else
        {

        }
    }
}
