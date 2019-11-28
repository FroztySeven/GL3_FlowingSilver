using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncrawlDetector : MonoBehaviour
{
    public static bool canUncrawl = true;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canUncrawl = false;
            player.GetComponent<Animator>().SetBool("cannotUncrawl", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canUncrawl = true;
            player.GetComponent<PlayerAnimations>().allowedCrawl = true;
            player.GetComponent<Animator>().SetBool("cannotUncrawl", false);
        }
    }
}
