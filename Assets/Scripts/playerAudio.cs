using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAudio : MonoBehaviour
{
    public AudioClip audioClipShooting;
    public AudioClip audioClipTeleport;
    public AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void playShootingSound()
    {
        audio.PlayOneShot(audioClipShooting);
    }

    public void playTeleportingSound()
    {
        audio.PlayOneShot(audioClipTeleport);
    }
}
