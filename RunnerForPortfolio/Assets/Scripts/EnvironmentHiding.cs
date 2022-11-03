using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentHiding : MonoBehaviour
{
    [SerializeField] private float hideDistance;
    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        HideEnvironmentObject();
    }

    private void HideEnvironmentObject()
    {
        bool isPlayerFarEnoughAway = playerTransform.position.z > transform.position.z + hideDistance;

        if (isPlayerFarEnoughAway)
            gameObject.SetActive(false);
    }
}
