using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ParticalTest : MonoBehaviour
{
    [SerializeField] private ParticleSystem flash;
    [SerializeField] string inputBtn;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inputBtn))
        {
            Instantiate(flash, transform.position, transform.rotation);
        }
    }
}
