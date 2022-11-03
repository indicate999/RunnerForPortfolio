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

    void Update()
    {
        if (playerTransform.position.z > transform.position.z + hideDistance)
            gameObject.SetActive(false);
    }
}
