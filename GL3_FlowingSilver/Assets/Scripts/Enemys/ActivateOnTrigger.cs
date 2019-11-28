using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnTrigger : MonoBehaviour
{
    [SerializeField] GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            obj.SetActive(true);
        }
    }
}
