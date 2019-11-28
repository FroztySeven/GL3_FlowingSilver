using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOn : MonoBehaviour
{
    [SerializeField] private string input;
    [SerializeField] private GameObject toDestroy;

    [SerializeField] private bool insideTrigger = false;

    private void Update()
    {
        if (insideTrigger && Input.GetKeyDown(input))
        {
            Destroy(toDestroy);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        insideTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        insideTrigger = false;
    }
}
