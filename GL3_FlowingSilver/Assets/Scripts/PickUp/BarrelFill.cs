using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelFill : MonoBehaviour
{
    [HideInInspector]public static bool barrelFill;
    public static float waterLevel = 0;

    [HideInInspector]public bool BarrelFilled;
    public GameObject waterInBarrell;
    private FillWithWater FillWithWaterCS;
    public TextMesh barrelText;
   
    public OnbuttonClick oBC;



    // Start is called before the first frame update
    void Start()
    {
        barrelFill = false;
        BarrelFilled = false;
        waterInBarrell.SetActive(false);
        
        FillWithWaterCS = GameObject.Find("Bucket").GetComponent<FillWithWater>();
        oBC = GameObject.Find("SceneEssentials").GetComponent<OnbuttonClick>();
        oBC.fillinstr.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && PickUp.InHand && barrelFill && FillWithWater.water > 0)
        {
            
            
            FillWithWaterCS.BucketFilled = false;
            
            waterLevel += FillWithWater.water;
            FillWithWater.water = 0;
             BarrelFilled = true;

        }

        
        if (waterLevel > 0)
        {
            waterInBarrell.SetActive(true);
        }
        else
        {
            waterInBarrell.SetActive(false);
        }

        barrelText.text = waterLevel.ToString() + "/200";

 

        if ( waterLevel >= 200)
        {
            //oBC.WinScreen.SetActive(true);
            oBC.tPOC.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            barrelFill = true;
            oBC.fillinstr.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            barrelFill = false;
            oBC.fillinstr.SetActive(false);
        }
    }
}
