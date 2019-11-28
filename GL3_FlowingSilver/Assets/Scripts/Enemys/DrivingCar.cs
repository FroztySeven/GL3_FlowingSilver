using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingCar : MonoBehaviour
{
    public float speed;
    public List<Transform> drivingPoints = new List<Transform>();
    private int pointCounter;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(drivingPoints[pointCounter].transform.position - transform.position), Time.deltaTime * speed * 4);

        if (Vector3.Distance(transform.position, drivingPoints[pointCounter].transform.position) < 3)
        {
            pointCounter++;
            if (pointCounter >= drivingPoints.Count)
            {
                Destroy(gameObject);
            }
        }
    }
}
