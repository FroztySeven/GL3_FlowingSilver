using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PickUp : MonoBehaviour
{



    private float Forward = 2;
    private float Upwards = 7;
    private GameObject onHand;
    private Transform Infront;
     public Rigidbody rb;
    public static bool InHand;
    public bool InRange;
    private GameObject parent;
    private PlayerAnimations cM;
    public GameObject PickupInstr;
    public GameObject PutdownInstr;
    private Collider spherecol;
    private Collider boxcol;
    private ParticleSystem bcpc;
    private bool hasThrown = false;

    [HideInInspector] public Text pickUpText;




    public Transform Player;

    void Start()
    {
        InHand = false;
        rb = GetComponent<Rigidbody>();
        PickupInstr.SetActive(false);
        PutdownInstr.SetActive(false);
        bcpc = gameObject.GetComponentInChildren<ParticleSystem>();
        spherecol = gameObject.GetComponent<SphereCollider>();
        boxcol = gameObject.GetComponent<BoxCollider>();
        onHand = GameObject.Find("InHand");
        Infront = GameObject.Find("Infront").GetComponent<Transform>();
        cM = Player.gameObject.GetComponent<PlayerAnimations>();
        Player = GameObject.Find("ModelRoot").GetComponent<Transform>();
        parent = GameObject.Find("child_v03");
        if (GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1)
        {
            Destroy(gameObject);
        }
        

        if (WaterVariables.bcInHand)
        {
            pickup();

        }
    }


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

     


        if (InHand && !cM.isCrawling)
        {
            PutdownInstr.SetActive(true);
            PickupInstr.SetActive(false);
        }
        else
        {
            PutdownInstr.SetActive(false);
        }

        if (InRange && !InHand && Input.GetKeyDown(KeyCode.E) && !cM.isCrawling )
        {
            GameObject.FindWithTag("Player").GetComponent<Animator>().SetBool("isPickup", true);
            pickup();
        }


        else if ( WaterVariables.bcInHand && InHand && Input.GetKeyDown(KeyCode.E) && !FillWithWater.InRangeOfWater  && !BarrelFill.barrelFill && !cM.isCrawling)
        {
            GameObject.FindWithTag("Player").GetComponent<Animator>().SetBool("isPickup", false);
            Throw();
        }

        else
        {

        }
        if (cM.isCrawling && InHand)
        {
            transform.position = Infront.transform.position;
        }
        else if (!cM.isCrawling && InHand)
        {
            transform.position = new Vector3(onHand.transform.position.x, onHand.transform.position.y, onHand.transform.position.z);
            
        }
        WaterVariables.bcInHand = InHand;
        InHand = WaterVariables.bcInHand;
        WaterVariables.bcInRange = InRange;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InRange = true;
            //pickUpText.text = "Press (E) to pick up bucket";

            if (!cM.isCrawling)
            {
                PickupInstr.SetActive(true);

            }
        }

        

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Building") && !InHand && hasThrown)
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 3, Player.transform.position.z);
            hasThrown = false;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InRange = false;
            //pickUpText.text = "";
            PickupInstr.SetActive(false);
        }
    }

    public void pickup()
    {
        InHand = true;
        InRange = false;
        spherecol.enabled = false;
        boxcol.enabled = false;
        bcpc.Stop();
        this.transform.parent = Player.transform;
        transform.position = new Vector3(onHand.transform.position.x, onHand.transform.position.y, onHand.transform.position.z);
        //transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y + 0.7f, parent.transform.position.z + 0.5f);
        Destroy(rb);

        //pickUpText.text = "Press (E) to throw bucket";
    }
    public void Throw()
    {
        hasThrown = true;
        InRange = false;
        InHand = false;

        this.transform.parent = null;
        spherecol.enabled = true;
        boxcol.enabled = true;
        rb = gameObject.AddComponent<Rigidbody>();
        bcpc.Play();
        rb.AddForce(Player.transform.forward * Forward, ForceMode.Impulse);
        rb.AddForce(Player.transform.up * Upwards, ForceMode.Impulse);
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
