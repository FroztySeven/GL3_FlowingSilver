﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCheck : MonoBehaviour
{
    public  bool isHeadColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        isHeadColliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isHeadColliding = false;
    }
}
