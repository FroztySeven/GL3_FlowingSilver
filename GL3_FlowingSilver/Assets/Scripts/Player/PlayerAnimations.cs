using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private GameObject player;
    private Transform playerTrans;

    public bool isWalking;
    public bool isRunning;
    public bool isCrawling;


    public bool allowedSprint = true;
    public float walkSpeed = 3.5f;
    public float sprintSpeed = 7.5f;

    public bool allowedCrawl = true;
    private UiDontdestroyOnload Uidol;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Uidol = GameObject.Find("SceneEssentials").GetComponent<UiDontdestroyOnload>();
    }

    // Update is called once per frame
    void Update()
    {
        //Walk animation & behaviour
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("isWalking", true);
            isWalking = true;
        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", false);
            isWalking = false;
        }

        //Running animation & behaviour
        if (isWalking)
        {
            if (allowedSprint)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {

                        //Uidol.RunInstr.SetActive(false);
                    

                    GetComponent<BasicWalkerController>().movementSpeed = sprintSpeed;
                    GetComponent<Animator>().SetBool("isSprinting", true);
                    isRunning = true;
                }
                else
                {
                    
                    GetComponent<BasicWalkerController>().movementSpeed = walkSpeed;
                    GetComponent<Animator>().SetBool("isSprinting", false);
                }
            }
        }
        else
        {
            //Uidol.RunInstr.SetActive(true);
            isRunning = false;
            GetComponent<BasicWalkerController>().movementSpeed = walkSpeed;
            GetComponent<Animator>().SetBool("isSprinting", false);
        }

        //Crawl animation & behaviour
        if (allowedCrawl)
        {
            if (Input.GetKeyDown(KeyCode.C) && (UncrawlDetector.canUncrawl == true))
            {
                playerTrans = GameObject.Find("PlayerController/ModelRoot/child_v03/mixamorig:Hips").transform;


                isCrawling = !isCrawling;

                if (isCrawling == true)
                {
                    //playerTrans.localPosition = new Vector3(0, 0.174f, 0);
                    //playerTrans.localRotation = Quaternion.Euler(90, 0, 0);
                    //mainCamera.camOffset = new Vector3(0, 0.1f, -2.5f);
                    //GetComponent<CapsuleCollider>().direction = 2;
                    //player.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.3f, 0);
                    GetComponent<CapsuleCollider>().enabled = false;
                    GetComponent<SphereCollider>().enabled = true;


                    GetComponent<Animator>().SetBool("isWalking", false);
                    GetComponent<Animator>().SetBool("hasCrawled", true);
                    allowedSprint = false;
                    StartCoroutine(DoFreezePlayer());

                    //player.GetComponent<SprintMovement>().allowedSprint = false;

                    //GameObject.Find("PlayerController/GirlModel_W38/pSphere1").SetActive(false);
                    //GameObject.Find("PlayerController/GirlModel_W38/pSphere2").SetActive(false);
                }
                else
                {
                    playerTrans.localPosition = new Vector3(0, 0.6248163f, 0);
                    //mainCamera.camOffset = new Vector3(0, 0.6f, -2.5f);
                    //GetComponent<CapsuleCollider>().direction = 1;
                    //GetComponent<CapsuleCollider>().center = new Vector3(0, 2.3f, 0);
                    //player.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.9f, 0);
                    GetComponent<CapsuleCollider>().enabled = true;
                    GetComponent<SphereCollider>().enabled = false;


                    GetComponent<Animator>().SetBool("isWalking", false);
                    GetComponent<Animator>().SetBool("hasCrawled", false);


                    allowedSprint = true;

                    //GameObject.Find("PlayerController/GirlModel_W38/pSphere1").SetActive(true);
                    //GameObject.Find("PlayerController/GirlModel_W38/pSphere2").SetActive(true);
                }
            }

            IEnumerator DoFreezePlayer()
            {
                player.GetComponent<CameraWalkerController>().enabled = false;
                yield return new WaitForSeconds(1.5f);
                player.GetComponent<CameraWalkerController>().enabled = true;
                StopCoroutine("DoFreezePlayer");
            }
        }

        //Change the direction of the capsule only if the two bools are enabled
        //if (GameObject.FindWithTag("Child").GetComponent<Animator>().GetBool("hasCrawled") == true && GameObject.FindWithTag("Child").GetComponent<Animator>().GetBool("isWalking") == true)
        //{
        //    player.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.2f, 0);
        //}
        //else if (GameObject.FindWithTag("Child").GetComponent<Animator>().GetBool("hasCrawled") == true)
        //{
        //    player.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.3f, 0);
        //}

        //Disable crawl when walking
        if (GetComponent<Animator>().GetBool("isWalking") == true)
        {
            allowedCrawl = false;
        }
        else
        {
            allowedCrawl = true;
        }
    }
}
