using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{
    public Slider HealthSlider;
    public Text PercentageText;
    public GameObject DeathScreen;
    public GameObject CrawlInstr;
    public GameObject StandUpInstr;
    private CameraWalkerController Mb;
    private PlayerAnimations cM;
    private UiDontdestroyOnload UiScript;


    // Start is called before the first frame update
    void Start()
    {
        Mb = GetComponent<CameraWalkerController>();
        Mb.enabled = true;
        CrawlInstr.SetActive(false);
        UiScript = GameObject.Find("SceneEssentials").GetComponent<UiDontdestroyOnload>();
        cM = GetComponent<PlayerAnimations>();
        StandUpInstr.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        HealthSlider.value = HealthSystem.health;
        PercentageText.text = HealthSystem.health.ToString("f0") + "%";


        if (HealthSystem.isDead)
        {
            DeathScreen.SetActive(true);
            HealthSystem.ResetHealth();
            Mb.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }



        /*
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            HealthSystem.TakeHealth(10);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HealthSystem.GiveHealth(10);
        }*/


        
        if(CrawlInstr.activeSelf && cM.isCrawling)
        {
            StandUpInstr.SetActive(true);
        }
        else
        {
            StandUpInstr.SetActive(false);
        }




    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crawl"))
        {

                
           CrawlInstr.SetActive(true);
            UiScript.RunInstr.SetActive(false);

        }
        if (other.CompareTag("WaterSource"))
        {
            FillWithWater.InRangeOfWater = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Crawl"))
        {
            CrawlInstr.SetActive(false);
            UiScript.RunInstr.SetActive(true);
        }
        if (other.CompareTag("WaterSource"))
        {
            FillWithWater.InRangeOfWater = false;
        }
        
    }

}
