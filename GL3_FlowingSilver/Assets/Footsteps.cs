
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Footsteps : MonoBehaviour
{
    
    
    public bool playerIsMoving;
    private bool starttimer;
    private float repeatSpeed = 0.5f;
    private float stepcooldown;
    public AudioSource fsteps;
    public AudioClip[] fstepsAudio;
    private bool playSteps;

    public PlayerAnimations bB;
 

    private void Start()
    {
        //InvokeRepeating("callFootsteps", 0, repeatSpeed);
        bB = this.GetComponent<PlayerAnimations>();
        

        fsteps = GetComponent<AudioSource>();


    }

    void Update()
    {





        stepcooldown -= Time.deltaTime;
        if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepcooldown < 0f)
        {
            fsteps.pitch = 1f + Random.Range(-0.2f, 0.2f);
            fsteps.PlayOneShot(fstepsAudio[Random.Range(0, 2)]);
            stepcooldown = repeatSpeed;
        }

        //callFootsteps(repeatSpeed - Time.deltaTime);
        /*
        if (Input.GetAxis("Vertical") >= 0.01f || Input.GetAxis("Horizontal") >= 0.01f || Input.GetAxis("Vertical") <= -0.01f || Input.GetAxis("Horizontal") <= -0.01f)
        {
            playerIsMoving = true;
            
        }
        else if(Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0)
        {
            playerIsMoving = false;
           
        }*/

        
        if (bB.isRunning)
        {
            repeatSpeed = 0.43f;
        }
        else
        {
            repeatSpeed = 0.5f;
        }
        //Debug.Log("speed " + repeatSpeed);

        //Debug.Log("Repeat speed" + stepcooldown);
        //repeatSpeed = Anim.GetFloat("Speed");
        //Debug.Log(" player is moving" + playerIsMoving);

        




        /*
        if (playerIsMoving && !fsteps.isPlaying && stepcooldown <= 0)
        {
            fsteps.pitch = 1f + Random.Range(-0.2f, 0.2f);
            fsteps.PlayOneShot(fstepsAudio[Random.Range(0, 3)]);
            stepcooldown = repeatSpeed;

            Debug.Log("Playing sound");
        }*/


        
    }

    public void callFootsteps(float v)
    {
        if (playerIsMoving)
        {
          
            fsteps.PlayOneShot(fstepsAudio[Random.Range(0,3)], 0.7F);
            fsteps.pitch = Random.Range(0.8f, 1f);
           // Debug.Log("Playing sound");
            
        }
    }
    private void OnDisable()
    {
        playerIsMoving = false;
    }

    private void playfootsteps()
    {
        fsteps.pitch = 1f + Random.Range(-0.2f, 0.2f);
        fsteps.PlayOneShot(fstepsAudio[Random.Range(0, 3)]);
        Debug.Log("Playing sound");
    }
}
