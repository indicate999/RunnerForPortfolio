using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneContainer : MonoBehaviour
{
    [SerializeField] private GameObject _plane;

    public GameObject Plane { get { return _plane; } }
}
