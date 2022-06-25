using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffector : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip ringSound, spikeSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRingSound()
    {
        audioSource.PlayOneShot(ringSound);
    }

    public void PlaySpikeSound()
    {
        audioSource.PlayOneShot(spikeSound);
    }
}
