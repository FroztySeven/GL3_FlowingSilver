using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadly_River : MonoBehaviour
{
    [SerializeField] float riverSpeed;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody>().drag = 5;
            other.GetComponent<Rigidbody>().AddForce(Vector3.forward * riverSpeed * 10, ForceMode.Acceleration);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody>().drag = 0;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            HealthSystem.Kill();
        }
    }
}
