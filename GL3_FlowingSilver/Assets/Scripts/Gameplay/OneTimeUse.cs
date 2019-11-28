using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeUse : MonoBehaviour
{
    public static bool isUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        if (isUsed)
        {
            Destroy(gameObject);
        }

        isUsed = true;     
    }
}
