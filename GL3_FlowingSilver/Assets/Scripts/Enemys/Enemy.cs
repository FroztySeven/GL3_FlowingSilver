using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject bullet;
    [SerializeField] float cooldown=2;
    [SerializeField] float delay = 0.2f;
    [SerializeField] float missingShoots = 2;
    [SerializeField] AudioClip gunAudio;
    float timeNext = 0;

    Vector3 direction;

    GameObject target;
    AudioSource audioSource;

    [SerializeField] float radius= 10;

        private void Start()
    {
        target= GameObject.FindGameObjectWithTag("Player");  //Write here the name of the script we're using for the player
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        this.transform.LookAt(target.transform.position);


        float dist = Vector3.Distance(this.transform.position, target.transform.position);
        if (dist < radius)
        {
            if (timeNext <= 0)
            {

                direction = target.transform.position - this.transform.position;
                RaycastHit info;
                if (Physics.Raycast(this.transform.position,  direction , out info, radius))
                {
                    if (info.transform.tag == "Player")
                    {
                        if (missingShoots > 0)
                        {
                            direction += Vector3.up*1.5f;
                            missingShoots--;
                        }          
                        StartCoroutine(Shooting());
                        timeNext = cooldown;
                    }
                }
            }
            else { timeNext -= Time.deltaTime; }
        }
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(delay);

        //audioSource.PlayOneShot(gunAudio);
        GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);    //Add flash
        b.GetComponent<Rigidbody>().AddForce(direction * 10, ForceMode.Impulse);
        Destroy(b,3);
    }
}
