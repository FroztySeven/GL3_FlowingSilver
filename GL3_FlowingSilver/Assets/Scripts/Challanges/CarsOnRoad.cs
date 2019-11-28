using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsOnRoad : MonoBehaviour
{
    private float currentVelocity;
    private float damageToGive;

    private void Start()
    {
        currentVelocity = FindObjectOfType<CarSpawner>().GetComponent<CarSpawner>().driveSpeed;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            HealthSystem.TakeHealth(currentVelocity * Vector3.Angle(col.contacts[0].normal, Vector3.forward) + 10);
        }
    }
}
