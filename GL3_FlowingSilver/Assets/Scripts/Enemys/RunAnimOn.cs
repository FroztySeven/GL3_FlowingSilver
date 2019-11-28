using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class RunAnimOn : MonoBehaviour
{
    public Walking_AI wAI;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (wAI.idle)
        {
            //print(wAI.idle);
            anim.SetBool("isWalking", true);
        }

        if (wAI.patroling || wAI.seesPlayer)
        {
            //print(wAI.patroling);
            anim.SetBool("isWlaking", true);
        }
    }
}
