using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    public static bool activeObj;

    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private Transform endOfTutorial;
    [SerializeField] private ThirdPersonOrbitCamBasic camController;
    [SerializeField] private GameObject bucket;
    public static float amountoftexts = 0;

    private void Start()
    {
        if (activeObj)
        {
            gameObject.SetActive(false);
            bucket.transform.position = endOfTutorial.position + new Vector3(1f, 1f, 1f);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Continue();
        }
        if(amountoftexts >= 11)
        {
            StartCoroutine(wait());
        }
        if (Input.GetKeyDown("t"))
        {
            Skip();
        }
    }

    private string[] tutorialText = new string[]
        {
            "'My family will die soon if I don't get water for them. \n I must find some.' \n \n Use WASD to move.",   //Start
            "'I need something to fetch water with.' \n \n Get the bucket",     //Find bucket
            "'This will do.' \n \n To pick up and put down the bucket, press E.",       //Pick bucket
            "'Now I need to get water' \n \n Fetch the water.",     //Fetch water
            "Press C to crawl under.",        //Crawl
            "When beside water press E to fill your bucket.",       //Fill bucket
            "'My familys barrel is in front of the house, \n I better fill that one.' \n \n Fill the barrel in front of the house",        //Go to barrel 
            "'Ouch!!' \n \n Press R heal yourself at the cost of the water \n you have fetched.",      //Lose health
            "Fill the barrel to its fullest for your family to survive. \n Press E to fill.",       //Fill barrel
            "It' not enough! I need to find more! \n \n Go the floating arrows to enter levels with water",     //Find water somewhere else
            "'So slow!' \n \n Hold shift to run. This will cost you water if you have any."     //Running
        };

    public void DisplayText(int num, GameObject go)
    {
        go.SetActive(false);
        tutorialPanel.SetActive(true);
        tutorialPanel.transform.GetChild(0).GetComponent<Text>().text = tutorialText[num];
        amountoftexts += 1;
        if (num == tutorialText.Length + 1)
            activeObj = true;
    }

    public void Continue()
    {
        tutorialPanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Skip()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = endOfTutorial.position;
        bucket.transform.position = endOfTutorial.position + new Vector3(1f, 1f, 1f);
        tutorialPanel.SetActive(false);
        activeObj = true;
        gameObject.SetActive(false);
    }


    IEnumerator wait()
    {
        yield return new WaitForSeconds(4);
        gameObject.SetActive(false);
        tutorialPanel.SetActive(false);
    }
}
