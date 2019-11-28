using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HomeManage : MonoBehaviour
{
    public Text waterAmount;
    public GameObject winMen;
    public GameObject fade;
    private CameraController tPOC;
    private OnbuttonClick Obc;
    public FillWithWater Fww;
    public Slider waterslider;
    private bool playerenter;


    public static float watercotnroll;
    public static float _waterAmount;
    public float watertobe;



    AudioClip waterDeliverClip;
    AudioSource sfxAudioSource;

    private void Start()
    {
        waterAmount.text = (int)_waterAmount + "%";
        tPOC = GameObject.Find("PlayerController").GetComponentInChildren<CameraController>();
        Obc = GameObject.Find("SceneEssentials").GetComponent<OnbuttonClick>();
        Fww = GameObject.Find("Bucket").GetComponent<FillWithWater>();
        sfxAudioSource = GameObject.FindWithTag("SFXAudio").GetComponent<AudioSource>();
        waterDeliverClip = Resources.Load("SFX/Water_Deliver") as AudioClip;
        waterslider = GameObject.Find("WaterAmountSlider").GetComponent<Slider>();
        waterslider.minValue = 0;
        waterslider.maxValue = 200;
        
        playerenter = false;
    }

    bool playWaterClipOnce = false;
    private void Update()
    {


        waterslider.value = _waterAmount;
        waterAmount.text = (int)_waterAmount + "%";


        if (playerenter && _waterAmount <= 200)
        {
            if(_waterAmount <= watercotnroll)
            {
                _waterAmount += watertobe * Time.deltaTime;
                if (!playWaterClipOnce)
                {
                    sfxAudioSource.PlayOneShot(waterDeliverClip);
                    playWaterClipOnce = true;
                }
            }

            else if (_waterAmount >= watercotnroll)
            {
                watertobe = 0;
                playerenter = false;
                playWaterClipOnce = false;
            }



        }
        /*
        if(_waterAmount >= watercotnroll)
        {
            watertobe = 0;
            playerenter = false;
        }*/

        if(_waterAmount >= 200)
        {
            _waterAmount = 200;
        }



        //Debug.Log("Water to be " + watertobe);
        //Debug.Log("WAter amount " + _waterAmount);
        //Debug.Log("Player enter " + playerenter);
        //Debug.Log("slider value " + waterslider.value);


        if (_waterAmount >= 200 && _waterAmount <= watercotnroll)
        {
            Time.timeScale = 0;
            Obc.WinScreen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            tPOC.enabled = false;


        }



    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Fww.hasWater)
        {

            watertobe = FillWithWater.water;
            watercotnroll += watertobe;
            playerenter = true;
            FillWithWater.water = 0;
            Fww.MaxBcWater = 100;
            
            if (_waterAmount >= 200)
            {
                Time.timeScale = 0;
                Obc.WinScreen.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                tPOC.enabled = false;
                
                
            }
            
            if(_waterAmount <= 199)
            {
                //Instantiate(fade);
            }

            Invoke("StartGame", 0.5f);
            

        }
    }

    void StartGame()
    {
        GameObject.FindGameObjectWithTag("Player").gameObject.transform.position = transform.GetChild(0).transform.position;
    }
}
