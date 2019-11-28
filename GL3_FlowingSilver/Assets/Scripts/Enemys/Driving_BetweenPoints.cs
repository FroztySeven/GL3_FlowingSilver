using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driving_BetweenPoints : MonoBehaviour
{
    public string pointNames;
    public List<GameObject> cars;
    public int spawnInterval = 1;
    public List<Transform> drivingPoints = new List<Transform>();
    public float carSpeed;

    private void Start()
    {

        InvokeRepeating("SpawnCars", 0.5f, spawnInterval);
    }

    void SpawnCars()
    {
        GameObject go = Instantiate(cars[Random.Range(0, cars.Count)], drivingPoints[0].position, drivingPoints[0].rotation);
        go.GetComponent<DrivingCar>().drivingPoints = drivingPoints;
        go.GetComponent<DrivingCar>().speed = carSpeed;
    }
}
