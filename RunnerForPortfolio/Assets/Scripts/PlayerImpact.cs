using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpact : MonoBehaviour
{
    [SerializeField] private UI _ui;
    [SerializeField] private SoundEffector _soundEffector;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ring")
        {
            _soundEffector.PlayRingSound();
            _ui.AddScore();

            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            _soundEffector.PlaySpikeSound();
            _ui.ShowRestartPanel();
        }
    }
}
