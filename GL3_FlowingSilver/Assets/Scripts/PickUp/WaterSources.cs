using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSources : MonoBehaviour
{

    public float RiverWater = 0;
    public bool InsideResource;
    [HideInInspector]public FillWithWater fWW;
    [HideInInspector] public WaterSourcesSave wSS;
    private UiDontdestroyOnload uiDO;


    // Start is called before the first frame update
    void Start()
    {
        fWW = GameObject.Find("Bucket").GetComponent<FillWithWater>();
        wSS = GameObject.Find("SceneEssentials").GetComponent<WaterSourcesSave>();
        uiDO = GameObject.Find("SceneEssentials").GetComponent<UiDontdestroyOnload>();
        uiDO.FillInstr.SetActive(false);
        InsideResource = false;
        

    }

    // Update is called once per frame
    void Update()
    {


        // filling water
        if(Input.GetKeyDown(KeyCode.E) && InsideResource && FillWithWater.water <100 && !fWW.bB.isWalking && PickUp.InHand)
        {
            
            
            if(RiverWater >= fWW.MaxBcWater)
            {
                FillWithWater.water += fWW.MaxBcWater;
                RiverWater -= fWW.MaxBcWater;


            }
            else if(RiverWater <= fWW.MaxBcWater)
            {
                
                FillWithWater.water += RiverWater;
                RiverWater = 0;

            }
            fWW.MaxBcWater -= FillWithWater.water;
            if(FillWithWater.water >= 100)
            {
                fWW.BucketFilled = true;

            }

            wSS.addToList(gameObject);
        }

      

        // if the water source is empty
        if(RiverWater <= 0 || !gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            uiDO.FillInstr.SetActive(false);
            uiDO.RunInstr.SetActive(true);
            RiverWater = 0;
            FillWithWater.InRangeOfWater = false;
            InsideResource = false;
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InsideResource = true;
            uiDO.FillInstr.SetActive(true);
            uiDO.RunInstr.SetActive(false);
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InsideResource = false;
            uiDO.FillInstr.SetActive(false);
            uiDO.RunInstr.SetActive(true);
        }
    }
}
