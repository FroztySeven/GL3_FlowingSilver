using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Manager;
    public GameObject bridge;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            StartCoroutine(PlayerDetected());
        }
    }

    IEnumerator PlayerDetected()
    {
        yield return new WaitForSeconds(0.05f);
        
        bridge.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        bridge.SetActive(true);
    }

}