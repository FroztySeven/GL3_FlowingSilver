using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnbuttonClick : MonoBehaviour
{

    private GameObject spawnpoint;
    private GameObject Player;
    private GameObject Bucket;
    public GameObject DeathScreen;
    public GameObject pausemenu;
    public GameObject WinScreen;
    public GameObject fillinstr;
    public GameObject reminder;
    private bool isPaused = false;
    private CameraWalkerController Mb;
    [HideInInspector] public CameraController tPOC;
    private FillWithWater fWW;
    private PickUp Pu;

    // Start is called before the first frame update
    void Start()
    {
        Mb = GameObject.Find("PlayerController").GetComponent<CameraWalkerController>();
        Mb.enabled = true;
        tPOC = GameObject.Find("PlayerController").GetComponentInChildren<CameraController>();
        Player = GameObject.Find("PlayerController");
        Bucket = GameObject.Find("Bucket");
        Pu = GameObject.Find("Bucket").GetComponent<PickUp>();
        fWW = GameObject.Find("Bucket").GetComponent<FillWithWater>();
        pausemenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


    }

    public GameObject tutorialPanel_obj;
    public GameObject buttonInstructions_obj;
    public GameObject topPanel_obj;
    public GameObject reminder_obj;
    // Update is called once per frame
    void Update()
    {
        spawnpoint = GameObject.FindGameObjectWithTag("SpawnPoint");



        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            if (tutorialPanel_obj.activeInHierarchy == true)
            {
                tutorialPanel_obj.SetActive(false);
            }

            if (reminder.activeInHierarchy == true)
            {
                reminder.SetActive(false);
            }

            buttonInstructions_obj.SetActive(false);
            topPanel_obj.SetActive(false);

            pausemenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            AudioListener.pause = true;
            Cursor.lockState = CursorLockMode.None;
            tPOC.enabled = false;
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            if (tutorialPanel_obj.activeInHierarchy == true)
            {
                tutorialPanel_obj.SetActive(true);
            }

            if (reminder.activeInHierarchy == true)
            {
                reminder.SetActive(true);
            }

            buttonInstructions_obj.SetActive(true);
            topPanel_obj.SetActive(true);

            Time.timeScale = 1;
            pausemenu.SetActive(false);
            AudioListener.pause = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            tPOC.enabled = true;
            isPaused = false;
        }





    }


    public void returntomenu()
    {
        AudioListener.pause = false;
        HealthSystem.ResetHealth();
        Time.timeScale = 1;
        FillWithWater.water = 0;
        fWW.BucketFilled = false;
        PickUp.InHand = false;
        BarrelFill.waterLevel = 0;
        HomeManage._waterAmount = 0;
        SceneManager.LoadScene("Menu");

        DisableHelicopter();

    }



    public void WinRestart()
    {
        Time.timeScale = 1;

        BarrelFill.waterLevel = 0;
        HomeManage._waterAmount = 0;
        HomeManage.watercotnroll = 0;
        tPOC.enabled = true;
        FillWithWater.water = 0;
        fWW.BucketFilled = false;
        HealthSystem.ResetHealth();
        //WinScreen.SetActive(false);
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        WinScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Player.transform.position = spawnpoint.transform.position;
        Player.transform.rotation = spawnpoint.transform.rotation;
    }



    public void DeathRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Player.transform.position = spawnpoint.transform.position;
        Player.transform.rotation = spawnpoint.transform.rotation;



        if (!PickUp.InHand)
        {
            Pu.pickup();
        }
        else
        {


        }

        DeathScreen.SetActive(false);
        FillWithWater.water = 0;
        fWW.BucketFilled = false;
        HealthSystem.ResetHealth();

        Mb.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void RegularRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Player.transform.position = spawnpoint.transform.position;
        Player.transform.rotation = spawnpoint.transform.rotation;


        FillWithWater.water = 0;
        HealthSystem.ResetHealth();
        if (!PickUp.InHand)
        {
            Pu.pickup();
        }
        else
        {


        }


        buttonInstructions_obj.SetActive(true);
        topPanel_obj.SetActive(true);
        BarrelFill.waterLevel = 0;

        fWW.BucketFilled = false;
        Cursor.visible = false;
        tPOC.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        pausemenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void continuebutton()
    {
        if (tutorialPanel_obj.activeInHierarchy == true)
        {
            tutorialPanel_obj.SetActive(true);
        }
        if (reminder.activeInHierarchy == true)
        {
            reminder.SetActive(true);
        }
        buttonInstructions_obj.SetActive(true);
        topPanel_obj.SetActive(true);
        tPOC.enabled = true;
        isPaused = false;

        Time.timeScale = 1;
        tPOC.enabled = true;
        pausemenu.SetActive(false);
        AudioListener.pause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void DisableHelicopter()
    {
        FunnyHelicopter.activateHelicopter = false;
        GameObject.FindWithTag("Player/Girl_v02").GetComponent<AudioSource>().Stop();
    }
}
