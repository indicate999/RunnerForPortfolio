using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffector : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _ringSound, _spikeSound;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayRingSound()
    {
        _audioSource.PlayOneShot(_ringSound);
    }

    public void PlaySpikeSound()
    {
        _audioSource.PlayOneShot(_spikeSound);
    }
}
