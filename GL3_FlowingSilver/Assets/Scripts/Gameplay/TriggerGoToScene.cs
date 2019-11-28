using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TriggerGoToScene : MonoBehaviour
{
    [SerializeField] int sceneNum;
    public static string sceneName;
    private OnbuttonClick oBC;
    public GameObject[] spawnpoint;
    //[SerializeField] Vector3 spawnBackOffset;

    AudioClip reminderClip;
    AudioSource sfxAudioSource;

    public static bool wasAtScene = false;

    private void Start()
    {

        oBC = GameObject.Find("SceneEssentials").GetComponent<OnbuttonClick>();
        oBC.reminder.SetActive(false);
        sfxAudioSource = GameObject.FindWithTag("SFXAudio").GetComponent<AudioSource>();
        reminderClip = Resources.Load("SFX/Reminder_Error") as AudioClip;;


        if (wasAtScene)
        {
            wasAtScene = false;
            GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.Find(sceneName).transform.position;
            GameObject.FindGameObjectWithTag("Player").transform.rotation = GameObject.Find(sceneName).transform.rotation;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && PickUp.InHand)
        {
            wasAtScene = true;
            SceneManager.LoadScene(sceneNum, LoadSceneMode.Single);
            sceneName = SceneManager.GetActiveScene().name;

            StartCoroutine("LoadToTownAsync", 1f);
        }
        else if(other.tag == "Player" && !PickUp.InHand)
        {
            sfxAudioSource.PlayOneShot(reminderClip);
            oBC.reminder.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        oBC.reminder.SetActive(false);
    }




    AsyncOperation async;
    public GameObject PlayLoadingCanvas;
    IEnumerator LoadToTownAsync()
    {
        PlayLoadingCanvas.SetActive(true);

        async = SceneManager.LoadSceneAsync(sceneNum);
        async.allowSceneActivation = false;


        while (async.isDone == false)
        {
            if (async.progress == 0.9f)
            {
                async.allowSceneActivation = true;
                StopAllCoroutines();
            }
            yield return null;
        }
    }
}
