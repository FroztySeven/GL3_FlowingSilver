using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyController : MonoBehaviour
{
    Vector3 originalPlayerPos;

    public float resetTime;
    public Text cheatText;

    AudioSource sfxAudioSource;
    AudioClip cheatClip;

    private string helicopterWord;
    private string helicopter_writtenWord;
    private bool helicopter_firstLetter = true;
    private float helicopter_resetCounter;
    private int helicopter_letterCounter;

    private string tutorialBlockWord;
    private string tutorial_block_writtenWord;
    private bool tutorial_block_firstLetter = true;
    private float tutorial_block_resetCounter;
    private int tutorial_block_letterCounter;

    private string townBlockWord;
    private string town_block_writtenWord;
    private bool town_block_firstLetter = true;
    private float town_block_resetCounter;
    private int town_block_letterCounter;

    private string farmBlockWord;
    private string farm_block_writtenWord;
    private bool farm_block_firstLetter = true;
    private float farm_block_resetCounter;
    private int farm_block_letterCounter;


    // Start is called before the first frame update
    void Start()
    {
        originalPlayerPos = GameObject.FindWithTag("Player").gameObject.transform.position;
        sfxAudioSource = GameObject.FindWithTag("SFXAudio").GetComponent<AudioSource>();
        cheatClip = Resources.Load("SFX/Cheat_Appear") as AudioClip; ;

        helicopterWord = "helicopter";
        tutorialBlockWord = "tutorial";
        townBlockWord = "town";
        farmBlockWord = "farm";
        cheatText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Typing "helicopter" or not
        if (Input.anyKeyDown)
        {
            if (Input.inputString == helicopterWord[helicopter_letterCounter].ToString())
            {
                helicopter_writtenWord += Input.inputString;
                helicopter_letterCounter++;
                print(helicopter_writtenWord);
            }

            if (helicopter_firstLetter)
            {
                helicopter_resetCounter = resetTime;
                helicopter_firstLetter = false;
            }

            for (int i = 0; i < helicopterWord.Length; i++)
            {
                if (helicopterWord == helicopter_writtenWord)
                {
                    FunnyHelicopter.activateHelicopter = true;
                    cheatText.text = "HELICOPTER";
                    cheatText.enabled = true;
                    GetComponent<Animator>().SetTrigger("SetAnim");
                    sfxAudioSource.PlayOneShot(cheatClip);
                    StartCoroutine("ResetTimer");
                }
            }
        }

        if (!helicopter_firstLetter)
        {
            helicopter_resetCounter = Mathf.MoveTowards(helicopter_resetCounter, 0, Time.deltaTime);
            if (helicopter_resetCounter == 0)
            {
                helicopter_firstLetter = true;
                helicopter_letterCounter = 0;
                helicopter_writtenWord = "";
            }
        }

        // Typing "tutorial" or not
        if (Input.anyKeyDown)
        {
            if (Input.inputString == tutorialBlockWord[tutorial_block_letterCounter].ToString())
            {
                tutorial_block_writtenWord += Input.inputString;
                tutorial_block_letterCounter++;
                print(tutorial_block_writtenWord);
            }

            if (tutorial_block_firstLetter)
            {
                tutorial_block_resetCounter = resetTime;
                tutorial_block_firstLetter = false;
            }

            for (int i = 0; i < tutorialBlockWord.Length; i++)
            {
                if (tutorialBlockWord == tutorial_block_writtenWord)
                {
                    cheatText.text = "TUTORIAL";
                    cheatText.enabled = true;
                    GetComponent<Animator>().SetTrigger("SetAnim");
                    sfxAudioSource.PlayOneShot(cheatClip);

                    StartCoroutine("CallTutorialBlockMap");
                    StartCoroutine("ResetTimer");
                }
            }
        }

        if (!tutorial_block_firstLetter)
        {
            tutorial_block_resetCounter = Mathf.MoveTowards(tutorial_block_resetCounter, 0, Time.deltaTime);
            if (tutorial_block_resetCounter == 0)
            {
                tutorial_block_firstLetter = true;
                tutorial_block_letterCounter = 0;
                tutorial_block_writtenWord = "";
            }
        }

        // Typing "town" or not
        if (Input.anyKeyDown)
        {
            if (Input.inputString == townBlockWord[town_block_letterCounter].ToString())
            {
                town_block_writtenWord += Input.inputString;
                town_block_letterCounter++;
                print(town_block_writtenWord);
            }

            if (town_block_firstLetter)
            {
                town_block_resetCounter = resetTime;
                town_block_firstLetter = false;
            }

            for (int i = 0; i < townBlockWord.Length; i++)
            {
                if (townBlockWord == town_block_writtenWord)
                {
                    cheatText.text = "TOWN";
                    cheatText.enabled = true;
                    GetComponent<Animator>().SetTrigger("SetAnim");
                    sfxAudioSource.PlayOneShot(cheatClip);

                    StartCoroutine("CallTownBlockMap");
                    StartCoroutine("ResetTimer");
                }
            }
        }

        if (!town_block_firstLetter)
        {
            town_block_resetCounter = Mathf.MoveTowards(town_block_resetCounter, 0, Time.deltaTime);
            if (town_block_resetCounter == 0)
            {
                town_block_firstLetter = true;
                town_block_letterCounter = 0;
                town_block_writtenWord = "";
            }
        }

        // Typing "farm" or not
        if (Input.anyKeyDown)
        {
            if (Input.inputString == farmBlockWord[farm_block_letterCounter].ToString())
            {
                farm_block_writtenWord += Input.inputString;
                farm_block_letterCounter++;
                print(farm_block_writtenWord);
            }

            if (farm_block_firstLetter)
            {
                farm_block_resetCounter = resetTime;
                farm_block_firstLetter = false;
            }

            for (int i = 0; i < farmBlockWord.Length; i++)
            {
                if (farmBlockWord == farm_block_writtenWord)
                {
                    cheatText.text = "FARM";
                    cheatText.enabled = true;
                    GetComponent<Animator>().SetTrigger("SetAnim");
                    sfxAudioSource.PlayOneShot(cheatClip);

                    StartCoroutine("CallFarmBlockMap");
                    StartCoroutine("ResetTimer");
                }
            }
        }

        if (!farm_block_firstLetter)
        {
            farm_block_resetCounter = Mathf.MoveTowards(farm_block_resetCounter, 0, Time.deltaTime);
            if (farm_block_resetCounter == 0)
            {
                farm_block_firstLetter = true;
                farm_block_letterCounter = 0;
                farm_block_writtenWord = "";
            }
        }
    }


    IEnumerator CallTutorialBlockMap()
    {  
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(2);
        yield return new WaitForSeconds(0.2f);
        GameObject.FindWithTag("Player").transform.position = originalPlayerPos;
        StopCoroutine("CallTutorialBlockMap");
    }
    IEnumerator CallTownBlockMap()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(3);
        yield return new WaitForSeconds(0.2f);
        GameObject.FindWithTag("Player").transform.position = originalPlayerPos + (transform.up * 20f);

        StopCoroutine("CallTownBlockMap");
    }
    IEnumerator CallFarmBlockMap()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(4);
        yield return new WaitForSeconds(0.2f);
        GameObject.FindWithTag("Player").transform.position = originalPlayerPos + (transform.up * 12f);

        StopCoroutine("CallFarmBlockMap");
    }

    IEnumerator ResetTimer()
    {  
        cheatText.GetComponent<Text>().enabled = true;

        yield return new WaitForSeconds(1f);
        cheatText.GetComponent<Text>().enabled = false;
        cheatText.enabled = false;
        cheatText.text = "";
        StopCoroutine("ResetTimer");
    }
}
