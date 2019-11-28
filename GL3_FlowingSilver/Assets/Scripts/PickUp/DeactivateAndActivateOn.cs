using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAndActivateOn : MonoBehaviour
{
    [SerializeField] private string input;
    [SerializeField] private GameObject toDeactivate;
    [SerializeField] private GameObject toActivate;

    private bool insideTrigger = false;

    private void Update()
    {
        if (insideTrigger && Input.GetKeyDown(input))
        {
            toDeactivate.SetActive(false);
            toActivate.SetActive(true);
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
