using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnyHelicopter : MonoBehaviour
{
    public static bool activateHelicopter = false;
    [SerializeField] float flySpeed, rotateSpeed;

    bool flyingUp, flyingDown, rotating;
    float currentRotSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Input.GetKeyDown("r"))
        //{
        //    rotating = !rotating;
        //}

        if (activateHelicopter)
        {
            //if (rotating)
            //{
            currentRotSpeed = Mathf.MoveTowards(currentRotSpeed, rotateSpeed * 10, Time.deltaTime * 10);
            GetComponent<CameraWalkerController>().enabled = false;
            GetComponent<PlayerAnimations>().enabled = false;
            GetComponent<Mover>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(1).transform.Rotate(Vector3.up * currentRotSpeed);
            StartCoroutine("StartFlying");
        }
        //}

        //if (!flyingUp && Input.GetKeyDown("t"))
        //{
        //    flyingUp = true;
        //    flyingDown = false;
        //}

        //if (flyingUp && Input.GetKeyDown("y"))
        //{
        //    flyingUp = false;
        //    flyingDown = true;
        //}

        if (flyingUp)
        {
            transform.Translate(Vector3.up * flySpeed * 0.1f);
        }

        //if (flyingDown)
        //{
        //    GetComponent<Rigidbody>().drag = 1;
        //}
    }
    IEnumerator StartFlying()
    {  
        yield return new WaitForSeconds(10f);
        if (!flyingUp)
        {
            flyingUp = true;
            flyingDown = false;
            print("started");
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        GetComponent<Rigidbody>().drag = 1;
        flyingDown = false;
    }
}

