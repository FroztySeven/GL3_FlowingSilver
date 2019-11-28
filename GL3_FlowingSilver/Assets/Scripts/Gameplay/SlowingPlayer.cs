using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingPlayer : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;

    float playerOriginWalkSpeed;
    float playerOriginRunSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOriginWalkSpeed = other.GetComponent<PlayerAnimations>().walkSpeed;
            playerOriginRunSpeed = other.GetComponent<PlayerAnimations>().sprintSpeed;
            other.GetComponent<PlayerAnimations>().walkSpeed = walkSpeed;
            other.GetComponent<PlayerAnimations>().sprintSpeed = runSpeed;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerAnimations>().walkSpeed = walkSpeed;
            other.GetComponent<PlayerAnimations>().sprintSpeed = runSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerAnimations>().walkSpeed = playerOriginWalkSpeed;
            other.GetComponent<PlayerAnimations>().sprintSpeed = playerOriginRunSpeed;
        }
    }
}
