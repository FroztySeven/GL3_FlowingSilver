using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRigidbodyOnTrigger : MonoBehaviour
{
    public Rigidbody rb;
    public float delay;

    private void Start()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Invoke("Activate", delay);
        }
    }

    void Activate()
    {
        rb.constraints = RigidbodyConstraints.None;
    }
}
