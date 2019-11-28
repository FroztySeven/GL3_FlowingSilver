using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] Vector3 rotSpeed;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotSpeed.x * Time.deltaTime, rotSpeed.y * Time.deltaTime, rotSpeed.z * Time.deltaTime));
    }
}
