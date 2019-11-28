using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAfterSec : MonoBehaviour
{
    [SerializeField] float seconds;
    [SerializeField] GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj.SetActive(false);
        Invoke("Activate", seconds);
    }

    void Activate()
    {
        obj.SetActive(true);
    }
}
