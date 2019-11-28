using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiDontdestroyOnload : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject MainCamera;
    public GameObject FillInstr;
    public GameObject RunInstr;
    [HideInInspector]public GameObject Sp;
    
    


    /*
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        Sp = GameObject.Find("SpawnPoint");

        Player.transform.position = Sp.transform.position;
        Player.transform.rotation = Sp.transform.rotation;
        //MainCamera.transform.rotation = Sp.transform.rotation;

    }*/

    void Start()
    {
        DontDestroyOnLoad(this);
        if (GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1)
        {
            Destroy(gameObject);
        }


    }
    /*
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

    }*/


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
