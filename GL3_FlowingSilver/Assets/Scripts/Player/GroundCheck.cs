using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public BasicBehaviour player;
    public bool isPlayerGrounded = false;
    public ParticleSystem ps;

    [Header("Fall damage system")]
    //public float damagePerSec;
    //public float takeDamageOn;
    [Space(10)]
    //public float inAirTimer;

    private float airStart;
    private float airEnd;
    private float fallHeight;

    public float damagePerHeight;

    void OnTriggerEnter(Collider col)
    {
        if (!isPlayerGrounded)
        {
            airEnd = transform.position.y;
            fallHeight = airStart - airEnd;

            //if (fallHeight >= 2.2f)
            if (fallHeight >= 1.2f)
            {
                HealthSystem.TakeHealth(fallHeight * damagePerHeight);
                Instantiate(ps, transform.position, Quaternion.identity);
            }
        }
    }

    void OnTriggerStay()
    {
        isPlayerGrounded = true;
    }


    void OnTriggerExit()
    {
        isPlayerGrounded = false;
        airStart = transform.position.y;
    }

    void Update()
    {
        // Fall damage system
        //if (!isPlayerGrounded)
        //{
        //    inAirTimer += Time.deltaTime;
        //}
        //else
        //{
        //    if (inAirTimer >= takeDamageOn)
        //    {
        //        HealthSystem.health -= (inAirTimer - takeDamageOn) * damagePerSec;
        //        ResetAirTimer();
        //    }
        //    else
        //    {
        //        ResetAirTimer();
        //    }
        //}

        if (HealthSystem.health <= 0)
        {
            HealthSystem.Kill();
        }
    }

    //void ResetAirTimer()
    //{
    //    inAirTimer = 0f;
    //}
}
