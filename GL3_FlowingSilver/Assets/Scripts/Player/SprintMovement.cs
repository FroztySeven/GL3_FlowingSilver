using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintMovement : MonoBehaviour
{
    public bool allowedSprint = true;
    public float walkSpeed = 0.5f;
    public float runSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (allowedSprint)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                GetComponent<BasicBehaviour>().sprint = true;
                GetComponent<MoveBehaviour>().walkSpeed = runSpeed;
                GetComponent<MoveBehaviour>().runSpeed = runSpeed;
            }
            else
            {
                GetComponent<BasicBehaviour>().sprint = false;
                GetComponent<MoveBehaviour>().walkSpeed = walkSpeed;
                GetComponent<MoveBehaviour>().runSpeed = walkSpeed;
            }
        }
    }
}
