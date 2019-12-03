using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDie : MonoBehaviour
{
    public List<GameObject> aiToRotate;
    public List<Quaternion> rotation;
    public List<ShootForwardAtInterval> rotatedAndKilled;
    public List<GameObject> guns;

    public ShootForwardAtInterval[] survived;
    public float interval;

    private bool dying;
    private float deathCounter;
    private int randAI;

    // Update is called once per frame
    void Update()
    {
        deathCounter = Mathf.MoveTowards(deathCounter, 0, Time.deltaTime);

        if (deathCounter == 0 && dying)
        {
            aiToRotate[randAI].transform.rotation = Quaternion.RotateTowards(aiToRotate[randAI].transform.rotation, rotation[randAI], Time.deltaTime * 0.01f);
            if (aiToRotate[randAI].transform.rotation == rotation[randAI])
            {
                KillOne();
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dying = true;
            SetTime();
        }
    }

    void SetTime()
    {
        deathCounter = interval;
        randAI = Random.Range(0, aiToRotate.Count);
    }

    void KillOne()
    {
        aiToRotate.Remove(aiToRotate[randAI]);
        rotatedAndKilled[randAI].enabled = false;
        rotatedAndKilled.Remove(rotatedAndKilled[randAI]);
        guns[randAI].SetActive(false);
        guns.Remove(guns[randAI]);

        if (aiToRotate.Count == 0)
        {
            for (int i = 0; i < survived.Length; i++)
            {
                survived[i].enabled = false;
            }
        }
        SetTime();
    }
}
