using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    Hidden hid;

    private void Start()
    {
        if (GameObject.Find("Hidden") != null)
            hid = GameObject.Find("Hidden").GetComponent<Hidden>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hid.hidden = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            hid.hidden = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            hid.hidden = false;
        }
    }
}
