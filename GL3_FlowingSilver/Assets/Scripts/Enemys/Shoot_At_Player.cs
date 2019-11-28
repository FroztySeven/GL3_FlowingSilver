using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Shoot_At_Player : MonoBehaviour
{
    [SerializeField] float shootSpread;
    [SerializeField] float timeBetweenShots;
    [SerializeField] GameObject bullet;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] bool machineGun;
    [SerializeField] GameObject playerDetector;
    AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootAtPlayer", 1, timeBetweenShots);
        source = GetComponent<AudioSource>();
    }

    void ShootAtPlayer()
    {
        if (playerDetector.GetComponent<Player_Detection>().hittingThePlayer)
        {
            if (machineGun)
            {
                int idx = Random.Range(3, 8);
                int counter = 0;
                for (int i = 0; i < idx; i++)
                {
                    Invoke("ShootPlayer", counter * 0.1f);
                    counter++;
                }
            }
            else
            {
                ShootPlayer();
            }
        }
        
    }

    void ShootPlayer()
    {
        float x = Random.Range((shootSpread / 2) * -1, shootSpread / 2);
        float y = Random.Range((shootSpread / 2) * -1, shootSpread / 2);
        float z = Random.Range((shootSpread / 2) * -1, shootSpread / 2);
        GameObject bb = Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(x, y, z));
        Instantiate(muzzleFlash, transform.position, transform.rotation);
    }
}
