using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonTest : MonoBehaviour
{
    [SerializeField] private GameObject camPivot;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rotSpeed;
    [Range(0, 1)]
    [SerializeField] private float airSpeed;
    [SerializeField] private float camSmoothTime;
    [SerializeField] private float maxCamHeight;
    [SerializeField] private float minCamHeight;
    [SerializeField] private float camSensitivity;

    public bool walking;
    public bool running;
    public bool grounded;

    private float vert, hor;
    private Rigidbody rb;
    private Camera cam;
    private Vector3 camVel = Vector3.zero;
    private LayerMask mask = ~(1 << 8);

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (camPivot != null)
            cam = camPivot.transform.GetChild(0).gameObject.GetComponent<Camera>();
    }

    private void Update()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        if (vert != 0 || hor != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                running = true;
                walking = false;
            }
            else
            {
                walking = true;
                running = false;
            }
        }
        else
        {
            walking = false;
            running = false;
        }
    }

    private void FixedUpdate()
    {
        if (walking && grounded)
        {
            transform.position += new Vector3(hor * walkSpeed * Time.deltaTime, 0, vert * walkSpeed * Time.deltaTime);
        }
        else if (running && grounded)
        {
            rb.velocity = transform.forward * runSpeed;
        }
        else if (!grounded && (running || walking))
        {
            rb.velocity = transform.forward * walkSpeed * airSpeed;
        }
        /*
        if (walking && grounded)
        {
            Vector3 v3 = new Vector3(hor * walkSpeed, rb.velocity.y, vert * walkSpeed);
            rb.velocity = transform.TransformDirection(v3);

        }
        else if (running && grounded)
        {
            Vector3 v3 = new Vector3(hor * runSpeed, rb.velocity.y, vert * runSpeed);
            rb.velocity = transform.TransformDirection(v3);
        }
        else if (!grounded && (running || walking))
        {
            Vector3 v3 = new Vector3(hor * walkSpeed * airSpeed, rb.velocity.y, vert * walkSpeed * airSpeed);
            rb.velocity = transform.TransformDirection(v3);
        }


        if (walking || running)
        {
            Vector3 velDir = rb.velocity;
            velDir.y = 0;

            if (walking)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(velDir), Time.fixedDeltaTime * rotSpeed * 10);
            }
            else
            {
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(0, camPivot.transform.rotation.y, 0, 1), Time.fixedDeltaTime * rotSpeed * 10);
            }
        }
        */

        //Camera movement
        camPivot.transform.position = Vector3.SmoothDamp(camPivot.transform.position, transform.position, ref camVel, camSmoothTime);

        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        
        

        camPivot.transform.Rotate(0, h, 0, Space.World);
        //transform.rotation = camPivot.transform.rotation;

        RaycastHit hitInfo;
        if (Physics.Raycast(camPivot.transform.position, cam.transform.TransformDirection(Vector3.back), out hitInfo, Mathf.Infinity, mask))
        {
            Debug.DrawRay(camPivot.transform.position, cam.transform.TransformDirection(Vector3.back) * hitInfo.distance, Color.red);
        }
    }
}
