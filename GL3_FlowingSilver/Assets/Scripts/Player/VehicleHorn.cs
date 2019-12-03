using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleHorn : MonoBehaviour
{
    public AudioClip[] carHornClips;
    public AudioClip[] truckHornClips;
    AudioClip hornClip;
    AudioSource audioSource;

    public bool isTruck;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (isTruck) // If the bool is ticked true through the Inspector
            {
                int index = Random.Range(0, truckHornClips.Length);
                hornClip = truckHornClips[index];
                audioSource.clip = hornClip;
                audioSource.Play();
            }
            else
            {
                int index = Random.Range(0, carHornClips.Length);
                hornClip = carHornClips[index];
                audioSource.clip = hornClip;
                audioSource.Play();
            }
        }
    }
}
