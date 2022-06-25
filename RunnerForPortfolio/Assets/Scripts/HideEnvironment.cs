using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideEnvironment : MonoBehaviour
{
    //This variable displays starting from what distance from the player's removal the element of the environment is hidden
    [SerializeField] private float hideDistance;
    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        //This code is needed to hide the elements of the environment after the player passes them for optimization
        if (playerTransform.position.z > transform.position.z + hideDistance)
            gameObject.SetActive(false);
    }
}
