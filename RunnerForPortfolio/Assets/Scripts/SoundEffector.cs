using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffector : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip ringSound, spikeSound;

    public void PlayRingSound()
    {
        audioSource.PlayOneShot(ringSound);
    }

    public void PlaySpikeSound()
    {
        audioSource.PlayOneShot(spikeSound);
    }
}
