using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] int textNum;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Tutorial").GetComponent<TutorialText>().DisplayText(textNum, gameObject);
        }
    }
}
