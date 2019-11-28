using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    [Header("Mouse movement")]
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;
    [SerializeField] private float moveSensitivity;
    [SerializeField] private GameObject cam;
    [SerializeField] private float camSmoothness;

    private float x, y, q;

    [Header("Scrollwheel zooming")]
    public float zoomSensitivity;
    public float zoomSpeed;
    public float zoomMin;
    public float zoomOutMax;

    private float zoom;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Camera rotation
        x += Input.GetAxis("Mouse X") * moveSensitivity * 0.1f;
        y += Input.GetAxis("Mouse Y") * moveSensitivity * -0.05f;
        y = Mathf.Clamp(y, minHeight, maxHeight);

        cam.transform.rotation = Quaternion.Euler(y, x, 0);

        cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position, camSmoothness);

        if (transform.GetComponent<Movement>().isMoving)
        {
            q = Mathf.MoveTowards(q, x, Time.deltaTime * 30 * moveSensitivity);

            transform.rotation = Quaternion.Euler(0, q, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, q, 0);
        }

        // Camera zooming
        // Camera zooming
        zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        zoom = Mathf.Clamp(zoom, zoomMin, zoomOutMax);
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoom, Time.deltaTime * zoomSpeed);
    }
}