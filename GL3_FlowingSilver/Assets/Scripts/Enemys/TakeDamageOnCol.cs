using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCol : MonoBehaviour
{
    [SerializeField] private float damageToTake;
    [SerializeField] private ParticleSystem hit;

    float timeOffset = 0;

    private void Update()
    {
        if (timeOffset != 0)
        {
            timeOffset = Mathf.MoveTowards(timeOffset, 0, Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && timeOffset == 0)
        {
            HealthSystem.TakeHealth(damageToTake);
            timeOffset = 0.5f;
            if (hit != null)
                Instantiate(hit, col.collider.transform.position - transform.position, Quaternion.identity);
        }
    }
}
