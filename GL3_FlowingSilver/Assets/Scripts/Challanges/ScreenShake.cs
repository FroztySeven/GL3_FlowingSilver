using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private float shakePower = 1;
    [SerializeField] private float shakeDistance = 20;

    private GameObject cam;
    private float rotCounter = 0;
    private float camDist;
    private bool countingUp;
    private bool shaking;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Camera");
        camDist = Vector3.Distance(cam.transform.position, transform.position);
        shaking = true;
        if (camDist < 1)
            camDist = 1;
        else if (camDist > shakeDistance)
            shaking = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (shaking && Time.timeScale != 0)
            Shake();
        
    }

    void Shake()
    {
        if (rotCounter == 1 || rotCounter == -1)
            countingUp = !countingUp;

        if (countingUp)
            rotCounter = Mathf.MoveTowards(rotCounter, 1, Time.deltaTime * shakePower * 500 / camDist);
        else
            rotCounter = Mathf.MoveTowards(rotCounter, -1, Time.deltaTime * shakePower * 500 / camDist);

        cam.transform.Rotate(Vector3.forward * rotCounter * shakePower);
    }
}
