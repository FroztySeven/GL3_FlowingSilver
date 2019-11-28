using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FillWithWater : MonoBehaviour
{
    private PickUp pickScript;
    public GameObject bucketwater;
    public static bool InRangeOfWater;
    private Material waterinbucketMat;
    public  bool BucketFilled;
    private Renderer BucketWaterRend;
    private GameObject waterSource;
    public static float water = 0;
    [HideInInspector] public float MaxBcWater;
    private float riverWater;
    public Text waterPercentageText;
    public GameObject HealInstr;
    [HideInInspector]public PlayerAnimations bB;
    private float removewaterat = 0.0f;
    [HideInInspector] public MoveBehaviour Mbh;
    private Rigidbody Rb;
    [HideInInspector]public GameObject waterImage;
    [HideInInspector] public bool hasWater;

    public ParticleSystem droppingWater;
    private bool loosingwater = false;


    public AudioClip bubbles;
    public AudioSource bcbubbles;

    AudioClip tutorialClip;
    AudioSource sfxAudioSource;


    [HideInInspector]public Slider WaterSlider;
    //public GameObject FillWithWaterText;
    
    
   


  
    // Start is called before the first frame update
    void Start()
    {
        InRangeOfWater = false;
        BucketFilled = false;
       
        pickScript = GetComponent<PickUp>();
        bcbubbles = GetComponent<AudioSource>();
        waterinbucketMat = bucketwater.GetComponent<Renderer>().material;
        WaterSlider = GameObject.Find("WaterSlider").GetComponent<Slider>();
        waterImage = GameObject.Find("WaterIcon");
        Rb = GameObject.Find("PlayerController").GetComponent<Rigidbody>();
        bB = GameObject.Find("PlayerController").GetComponent<PlayerAnimations>();
        HealInstr.SetActive(false);
        //WaterSlider = GameObject.Find("WaterSlider").GetComponent<Slider>();
        //BucketFilled = WaterVariables.WaterFilled;
        WaterSlider.maxValue = 100;
        WaterSlider.minValue = 0;
        /*
        if (WaterVariables.WaterFilled)
        {
            bucketwater.SetActive(true);
            water = WaterVariables.WaterAmount;
            BucketFilled = true;
        }
        */
        MaxBcWater = 100;
        droppingWater.Stop();
        loosingwater = false;

        sfxAudioSource = GameObject.FindWithTag("SFXAudio").GetComponent<AudioSource>();
        tutorialClip = Resources.Load("SFX/Tutorial_Appear") as AudioClip;
    }

    // Update is called once per frame
    void Update()
    {
        waterPercentageText.text = water.ToString("f0") + "%";

        

        //fillwith water
        if (InRangeOfWater && PickUp.InHand && Input.GetKeyDown(KeyCode.E) && water <= 100 && !bB.isWalking)
        {

            bucketwater.SetActive(true);
            bcbubbles.PlayOneShot(bubbles);



            //StartCoroutine(EmptyWaterSource());
            //InRangeOfWater = false;
            //waterSource.SetActive(false);
            //RiverMat = waterinbucketMat;





        }
        //empty the water

        /*        
        if ( BucketFilled && !InRangeOfWater && pickScript.InHand && Input.GetMouseButtonDown(1))
        {
            water = 0;
            BucketFilled = false;
            bucketwater.SetActive(false);
        }*/
        
        //heal with the water
        if (Input.GetKey(KeyCode.R) && HealthSystem.health < 100 && water > 0 && PickUp.InHand)
        {
            
            HealthSystem.GiveHealth(1);
            WaterVariables.WaterAmount = water;
            water -= 1;
            MaxBcWater += 1;
            HealthSystem.healHealth -= 1;
        }

        if(water > 0 && PickUp.InHand)
        {
            HealInstr.SetActive(true);
            hasWater = true;
        }
        else
        {
            HealInstr.SetActive(false);
            hasWater = false;
        }


        if (water >= 100)
        {
            BucketFilled = true;

        }
        else
        {
            BucketFilled = false;
        }



        //Debug.Log("max bucket water" + MaxBcWater);

        //setting the slider value
        if (PickUp.InHand)
        {
           WaterSlider.gameObject.SetActive(true);
            waterImage.SetActive(true);
            WaterSlider.value = water;
            //Debug.Log("I am " + gameObject.name);




        }
        else
        {
            WaterSlider.value = 0;
            WaterSlider.gameObject.SetActive(false);
            waterImage.SetActive(false);
            //Debug.Log("WADUP");
        }

        //Debug.Log("is running" + bB.isRunning);

        if (PickUp.InHand && bB.isRunning &&  water > 0 && Time.time >= removewaterat )
        {
            water -= 1f;
            MaxBcWater += 1f;
            removewaterat = Time.time + 1.0f;
            droppingWater.Play();
        }
        else if(!bB.isRunning || water == 0)
        {
            droppingWater.Stop();
        }


        //Debug.Log("Max bucketwater " + MaxBcWater);

        if (water > 0)
        {
            bucketwater.SetActive(true);
        }

        if( water <= 0)
        {
            water = 0;
            MaxBcWater = 100;
            //Debug.Log("Empty");
            BucketFilled = false;
            bucketwater.SetActive(false);
        }
        
        if(water >= 100)
        {
            BucketFilled = true;
            water = 100;
        }

        if(MaxBcWater <= 0)
        {
            MaxBcWater = 0;
        }
        if(MaxBcWater >= 100)
        {
            MaxBcWater = 100;
        }

        if (HealthSystem.health <= 0 || HealthSystem.isDead)
        {
            BucketFilled = false;
            water = 0;
            bucketwater.SetActive(false);
        }

        WaterSlider.value = water;


         if(water >= 100)
         {
            bucketwater.transform.localScale = new Vector3(0.01725732f, 0.007549673f, 0.01736669f);
            bucketwater.transform.localPosition = new Vector3(0, 0.0017f, 0);
        }
         if(water <= 75)
         {
            bucketwater.transform.localScale = new Vector3(0.01725732f, 0.005380879f, 0.01736669f);
            bucketwater.transform.localPosition = new Vector3(0, 0.0026904395f, 0);

        }
        if (water <= 50)
         {
            bucketwater.transform.localScale = new Vector3(0.01725732f, 0.004318478f, 0.01736669f);
            bucketwater.transform.localPosition = new Vector3(0,  0.002159239f, 0);

        }
        if (water <= 25)
         {
            bucketwater.transform.localScale = new Vector3(0.01725732f, 0.002295444f, 0.01736669f);
            bucketwater.transform.localPosition = new Vector3(0, 0.001147722f, 0);
        }
        if (water <= 10)
        {
            bucketwater.transform.localScale = new Vector3(0.01725732f, 0.0008281272f, 0.01736669f);
            bucketwater.transform.localPosition = new Vector3(0, 0.0004140636f, 0);



        }

        /*
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            water -= 10;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            water += 10;
        }*/




        if(MaxBcWater <= 0)
        {

            MaxBcWater = 0;
        }


    }
    //checks if you are in range of water
    private void OnTriggerEnter(Collider other)
    {
        if ( !InRangeOfWater && other.gameObject.CompareTag("WaterSource"))
        {
            InRangeOfWater = true;
            

            //pickScript.PickUpText.text = "Press Left mouse button to fill bucket";
            if (!BucketFilled)
            {
                bucketwater.GetComponent<Renderer>().material = other.GetComponent<Renderer>().material;
                //riverWater = other.GetComponent<WaterSources>().RiverWater;
                //other.GetComponent<WaterSources>().RiverWater = riverWater;


            }
            
            if (BucketFilled)
            {
                //other.GetComponent<WaterSources>().RiverWater = riverWater;
            }
            
            waterSource = other.gameObject;


        }
        //Debug.Log("WaterSource  water " + riverWater);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WaterSource"))
        {
            InRangeOfWater = false;
            
           
            //pickScript.PickUpText.text = "Press Left mouse button to empty bucket";
        }

        
    }
    
    IEnumerator EmptyWaterSource()
    {
        yield return new WaitForSeconds(1);
        waterSource.SetActive(false);
        InRangeOfWater = false;
    }


}
