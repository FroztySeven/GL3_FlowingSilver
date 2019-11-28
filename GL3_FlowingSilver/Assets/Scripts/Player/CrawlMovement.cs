using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlMovement : MonoBehaviour
{
    public bool isCrawling;

    private GameObject player;
    private Transform playerTrans;
    private bool allowedCrawl = true;
    private ThirdPersonOrbitCamBasic mainCamera;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (allowedCrawl)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                playerTrans = GameObject.Find("PlayerController/child_v03/mixamorig:Hips").transform;
                mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<ThirdPersonOrbitCamBasic>();


                isCrawling = !isCrawling;

                if (isCrawling == true)
                {
                    playerTrans.localPosition = new Vector3(0, 0.174f, 0);
                    playerTrans.localRotation = Quaternion.Euler(90, 0, 0);
                    //mainCamera.camOffset = new Vector3(0, 0.1f, -2.5f);
                    player.GetComponent<CapsuleCollider>().direction = 2;
                    player.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.3f, 0);


                    GameObject.FindWithTag("Child").GetComponent<Animator>().SetBool("isWalking", false);
                    GameObject.FindWithTag("Child").GetComponent<Animator>().SetBool("hasCrawled", true);
                    StartCoroutine(DoFreezePlayer());

                    player.GetComponent<SprintMovement>().allowedSprint = false;

                    //GameObject.Find("PlayerController/GirlModel_W38/pSphere1").SetActive(false);
                    //GameObject.Find("PlayerController/GirlModel_W38/pSphere2").SetActive(false);
                }
                else
                {
                    playerTrans.localPosition = new Vector3(0, 0.6248163f, 0);
                    playerTrans.localRotation = Quaternion.Euler(0, 0, 0);
                    //mainCamera.camOffset = new Vector3(0, 0.6f, -2.5f);
                    player.GetComponent<CapsuleCollider>().direction = 1;
                    player.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.9f, 0);


                    GameObject.FindWithTag("Child").GetComponent<Animator>().SetBool("isWalking", false);
                    GameObject.FindWithTag("Child").GetComponent<Animator>().SetBool("hasCrawled", false);


                    player.GetComponent<SprintMovement>().allowedSprint = true;

                    //GameObject.Find("PlayerController/GirlModel_W38/pSphere1").SetActive(true);
                    //GameObject.Find("PlayerController/GirlModel_W38/pSphere2").SetActive(true);
                }
            }
            IEnumerator DoFreezePlayer()
            {
                player.GetComponent<BasicBehaviour>().enabled = false;
                yield return new WaitForSeconds(1.5f);
                player.GetComponent<BasicBehaviour>().enabled = true;
                StopCoroutine("DoFreezePlayer");
            }
        }

        //Change the direction of the capsule only if the two bools are enabled
    if (GameObject.FindWithTag("Child").GetComponent<Animator>().GetBool("hasCrawled") == true && GameObject.FindWithTag("Child").GetComponent<Animator>().GetBool("isWalking") == true)
        {
            player.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.2f, 0);
        }
        else if (GameObject.FindWithTag("Child").GetComponent<Animator>().GetBool("hasCrawled") == true)
        {
            player.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.3f, 0);
        }

        //Disable crawl when walking
        if (GameObject.FindWithTag("Child").GetComponent<Animator>().GetBool("isWalking") == true)
        {
            allowedCrawl = false;
        }
        else
        {
            allowedCrawl = true;
        }
    }
}
