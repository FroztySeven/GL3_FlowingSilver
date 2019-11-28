using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnInterval : MonoBehaviour
{
    [SerializeField] float interval = 1f;
    [SerializeField] GameObject obj;

    bool active;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Able", interval, interval);
    }

    void Able()
    {
        active = !active;
        obj.SetActive(active);
    }
}
