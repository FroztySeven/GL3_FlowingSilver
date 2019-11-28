using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineField_00 : MonoBehaviour
{
    [SerializeField] int minesDensity;
    [SerializeField] int notMineDensity;
    [SerializeField] GameObject mines;
    [SerializeField] GameObject[] notMines;

    int numberOfMines;
    int numberOfNotMines;

    // Start is called before the first frame update
    void Start()
    {
        numberOfNotMines = (int)transform.localScale.x * (int)transform.localScale.z * notMineDensity;
        for (int i = 0; i < numberOfNotMines; i++)
        {
            GameObject idx = Instantiate(notMines[Random.Range(0, notMines.Length)], new Vector3(Random.Range(transform.position.x - transform.localScale.x * 5, transform.position.x + transform.localScale.x * 5),
                transform.position.y,
                Random.Range(transform.position.z - transform.localScale.z * 5, transform.position.z + transform.localScale.z * 5)), Quaternion.Euler(0, Random.Range(0, 360), 0));
            idx.transform.parent = transform;
        }

        numberOfMines = (int)transform.localScale.x * (int)transform.localScale.z * minesDensity;
        for (int i = 0; i < numberOfMines; i++)
        {
            GameObject idx = Instantiate(mines, new Vector3(Random.Range(transform.position.x - transform.localScale.x * 5, transform.position.x + transform.localScale.x * 5),
                transform.position.y , 
                Random.Range(transform.position.z - transform.localScale.z * 5, transform.position.z + transform.localScale.z * 5)), Quaternion.Euler(0, Random.Range(0, 360), 0));
            idx.transform.parent = transform;
        }

    }
}
