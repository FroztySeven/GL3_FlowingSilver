using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tutorial_01 : MonoBehaviour
{
    public static bool beenToLevel;

    public GameObject player;
    public GameObject bucket;
    public GameObject waterSource;
    public Text txtBox;

    AudioClip tutorialClip;
    AudioSource sfxAudioSource;

    private int tutorialTicks;
    private string[] tutorialText =
    {
        "Use WASD to move",
        "Fetch the bucket, you can fill it with water",
        "There is some water under that tree. Go get it",
        "Good job! Now, get the water back to the house",
        "It's a start, but it's not enough! \n Search for more water other places"
    };


    // Start is called before the first frame update
    void Start()
    {

        sfxAudioSource = GameObject.FindWithTag("SFXAudio").GetComponent<AudioSource>();
        tutorialClip = Resources.Load("SFX/Tutorial_Appear") as AudioClip; ;

        if (beenToLevel)
        {
            Destroy(gameObject);
            txtBox.transform.parent.gameObject.SetActive(false);
            waterSource.SetActive(false);
        }
        else
        {
            beenToLevel = true;
        }

        txtBox.text = "Search trough the world, find and fetch water \n See what button you should to press in the bottom left";
        Invoke("NextText", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t"))
            EndTutorial();
        if (Input.GetKeyDown("space"))
            HidePanel();

        if ((Input.GetKeyDown("w") || Input.GetKeyDown("d") || Input.GetKeyDown("s") || Input.GetKeyDown("a")) && (tutorialTicks == 1 || tutorialTicks == 0))
        {
            tutorialTicks = 1;
            NextText();
            CancelInvoke();
        }

        if (PickUp.InHand && tutorialTicks == 2)
        {
            NextText();
        }

        if (FillWithWater.water > 0 && tutorialTicks == 3)
        {
            NextText();
        }
        if (HomeManage._waterAmount > 0 && tutorialTicks == 4)
        {
            NextText();
            Invoke("EndTutorial", 10f);
        }
    }

    void NextText()
    {
        sfxAudioSource.PlayOneShot(tutorialClip);

        txtBox.transform.parent.gameObject.SetActive(true);
        txtBox.text = tutorialText[tutorialTicks];
        tutorialTicks++;
    }

    void HidePanel()
    {
        txtBox.transform.parent.gameObject.SetActive(false);
    }

    void EndTutorial()
    {
        HidePanel();

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        HidePanel();
    }

    private void OnTriggerEnter(Collider other)
    {
        txtBox.transform.parent.gameObject.SetActive(true);
        txtBox.text = "Press 'C' to crawl";
        GetComponent<BoxCollider>().enabled = false;
    }
}
