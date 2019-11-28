using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSounds : MonoBehaviour
{

    public AudioClip[] dogclips;
    private AudioSource dogaoudio;
    private Walking_AI Dogscript;
    private float soundcooldown;
    private float soundspeed = 1.5f;
    private bool playsound;
    // Start is called before the first frame update
    void Start()
    {
        dogaoudio = GetComponent<AudioSource>();
        Dogscript = GetComponent<Walking_AI>();
        playsound = true;
    }

    // Update is called once per frame
    void Update()
    {


        soundcooldown -= Time.deltaTime;
        if (Dogscript.seesPlayer && soundcooldown < 0f)
        {

            dogaoudio.pitch = 1f + Random.Range(-0.2f, 0.2f);
            dogaoudio.PlayOneShot(dogclips[Random.Range(0, dogclips.Length)]);
            soundcooldown = soundspeed;
        }





    }
}
