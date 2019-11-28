using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public List<GameObject> rocks;
    public float rockForce;
    public int spawnInterval;

    private float counter;

    private void Update()
    {
        if (counter <= 0)
        {
            counter = Random.Range(spawnInterval / 2, spawnInterval * 2);
            GameObject go = Instantiate(rocks[Random.Range(0, rocks.Count)], transform.position, Random.rotation);
            go.GetComponent<Rigidbody>().AddForce(transform.forward * rockForce, ForceMode.Impulse);
            go.transform.parent = transform;
        }

        counter -= Time.deltaTime;
    }
}
