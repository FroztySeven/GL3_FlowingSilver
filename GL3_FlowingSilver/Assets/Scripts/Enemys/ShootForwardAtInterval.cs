using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootForwardAtInterval : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private float shootSpread;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private bool machineGun;

    private float shootCounter;

    private void Start()
    {

    }

    private void Update()
    {
        if (shootCounter == 0)
        {
            if (machineGun)
            {
                int idx = Random.Range(3, 8);
                int counter = 0;
                for (int i = 0; i < idx; i++)
                {
                    Invoke("Shoot", counter * 0.1f);
                    counter++;
                }
            }
            else
            {
                Shoot();
            }
            shootCounter = timeBetweenShots;
        }
        else
        {
            shootCounter = Mathf.MoveTowards(shootCounter, 0, Time.deltaTime);
        }
    }

    void Shoot()
    {
        float x = Random.Range((shootSpread / 2) * -1, shootSpread / 2);
        float y = Random.Range((shootSpread / 2) * -1, shootSpread / 2);
        float z = Random.Range((shootSpread / 2) * -1, shootSpread / 2);
        Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(x, y, z));
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, transform.position, transform.rotation);
    }
}
