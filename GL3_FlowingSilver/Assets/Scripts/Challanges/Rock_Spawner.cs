using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Spawner : MonoBehaviour
{
    [SerializeField] GameObject rock;
    [SerializeField] Transform fpoint;
    [SerializeField] Transform spoint;
    [SerializeField] Transform tpoint;
    private bool Passed;
    // Start is called before the first frame update
    void Start()
    {
        Passed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Passed == true)
        {
            StartCoroutine(SpawnRock());
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Passed = true;
        }
    }

    IEnumerator SpawnRock()
    {
        Passed = false;
        yield return new WaitForSeconds(4);
        Instantiate(rock, fpoint.position,Quaternion.identity);
        Instantiate(rock, spoint.position, Quaternion.identity);
        Instantiate(rock, tpoint.position, Quaternion.identity);
        Passed = true;
    }
}
