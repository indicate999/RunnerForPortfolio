using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedSettingsData", menuName = "My Assets/SpeedSettings Data")]
public class SpeedSettingsData : ScriptableObject
{
    [SerializeField] private float _forwardButtonSpeed;
    [SerializeField] private float _controlButtonSpeed;
    [SerializeField] private float _forwardTouchSpeed;
    [SerializeField] private float _controlTouchSpeed;

    public float ForwardButtonSpeed { get { return _forwardButtonSpeed; } }
    public float ControlButtonSpeed { get { return _controlButtonSpeed; } }
    public float ForwardTouchSpeed { get { return _forwardTouchSpeed; } }
    public float ControlTouchSpeed { get { return _controlTouchSpeed; } }
}
