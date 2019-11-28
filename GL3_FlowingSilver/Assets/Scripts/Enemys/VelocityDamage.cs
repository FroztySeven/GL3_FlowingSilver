using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityDamage : MonoBehaviour
{
    public float damage = 1;
    [SerializeField] private ParticleSystem hit;
    [SerializeField] bool becomesSmaller = true;

    Rigidbody rb;
    float vel;
    bool shrinking = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vel = rb.velocity.magnitude;
        if (shrinking)
            Shrink();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && vel > 3f)
        {
            HealthSystem.TakeHealth(vel * damage);
            if (hit != null)
                Instantiate(hit, collision.contacts[0].point, Quaternion.identity);
        }
        if (collision.gameObject.tag != "Building")
        {
            shrinking = true;
        }
    }

    void Shrink()
    {
        if (becomesSmaller)
        {
            transform.localScale -= transform.localScale * 0.005f;
            Destroy(gameObject, 5f);
        }
    }
}
