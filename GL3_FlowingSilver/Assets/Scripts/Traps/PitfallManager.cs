using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitfallManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool reactivate = false;
    public GameObject Pitfall;
    private void Update()
    {
        if (reactivate == true)
        {
            StartCoroutine(Activate(Pitfall));
        }
    }


    public IEnumerator Activate (GameObject Pitfall)
    {
        yield return new WaitForSeconds(10);
        Pitfall.SetActive(true);
    }
}
