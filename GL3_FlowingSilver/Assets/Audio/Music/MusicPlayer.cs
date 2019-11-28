using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public AudioClip[] soundtracks;
    private AudioSource musicSource;


    // Use this for initialization
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!musicSource.isPlaying)
        {

            musicSource.clip = GetRandomClip();
            musicSource.Play();
        }
    }

    private AudioClip GetRandomClip()
    {
        return soundtracks[Random.Range(0, soundtracks.Length)];
    }



    public void ShuffleTrack()
    {
        if (musicSource.isPlaying)
        {

            musicSource.clip = GetRandomClip();
            musicSource.Play();
            musicSource.volume = 0.3f;
        }
    }
}
