using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;

    [HideInInspector] public bool isMoving;

    private float side, forward;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        forward = Input.GetAxis("Vertical");
        side = Input.GetAxis("Horizontal");

        if (forward != 0)
        {
            transform.Translate(Vector3.forward * speed * 0.01f * forward);
            //GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Time.deltaTime * speed * forward);
            isMoving = true;
        }

        if (side != 0)
        {
            transform.Translate(Vector3.right * speed * 0.005f * side);
            //GetComponent<Rigidbody>().MovePosition(transform.position + transform.right * Time.deltaTime * speed * side);
            isMoving = true;
        }

        if (forward == 0 && side == 0)
        {
            isMoving = false;
        }
    }
}