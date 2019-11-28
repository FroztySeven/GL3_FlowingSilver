using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageFromCenter : MonoBehaviour
{
    public float multiplier = 1f;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            HealthSystem.health -= ((10f * Time.deltaTime) / Vector3.Distance(other.transform.position, transform.position)) * multiplier;
        }
    }
}
