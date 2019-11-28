using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        transform.parent.GetComponent<ThirdPersonTest>().grounded = true;
    }

    private void OnTriggerStay(Collider other)
    {
        transform.parent.GetComponent<ThirdPersonTest>().grounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        transform.parent.GetComponent<ThirdPersonTest>().grounded = false;
    }
}
