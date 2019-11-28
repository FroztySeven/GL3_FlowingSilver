using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTriggerController : MonoBehaviour
{
    public bool GameHub;
    public bool CliffBridge;

    void OnTriggerEnter(Collider other)
    {
        if (GameHub)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene(1);
                
            }
        }
        if (CliffBridge)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
