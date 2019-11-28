using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeActivateOnTrigger : MonoBehaviour
{
    public GameObject fromPoint;
    public GameObject toPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fromPoint.transform.position = toPoint.transform.position;
        }
    }
}
