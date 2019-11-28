using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] float spawnInterval;
    public float driveSpeed;
    [SerializeField] float destroyTime;
    [SerializeField] GameObject[] vehicles;

    List<GameObject> spawnedCars = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCars", spawnInterval, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            for (int i = 0; i < spawnedCars.Count; i++)
            {
                spawnedCars[i].transform.Translate(Vector3.forward * driveSpeed * Time.deltaTime);
            }
        }       
    }

    void SpawnCars()
    {
        if (Time.timeScale != 0)
        {
            spawnedCars.Add(Instantiate(vehicles[Random.Range(0, vehicles.Length)], transform.position, transform.rotation));
            Invoke("DestroyCars", destroyTime);
        }
    }

    void DestroyCars()
    {
        Destroy(spawnedCars[0]);
        spawnedCars.Remove(spawnedCars[0]);
    }
}
