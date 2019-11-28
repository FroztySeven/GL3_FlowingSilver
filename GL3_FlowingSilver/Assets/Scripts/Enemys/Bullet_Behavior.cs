using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behavior : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 1;
    [Range(0, 100)]
    [SerializeField] float damage;
    [SerializeField] ParticleSystem hitParticle;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        Destroy(gameObject, 2);
    }

    private void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        Vector3 hitDir = other.contacts[0].normal;
        Quaternion hitRot = Quaternion.LookRotation(hitDir, transform.forward);

        Instantiate(hitParticle, transform.position, hitRot);

        if (other.gameObject.tag == "Player")
        {
            HealthSystem.TakeHealth(damage);
        }

        Destroy(gameObject);
    }
}

