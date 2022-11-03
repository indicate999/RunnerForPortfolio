using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnvironmentSettingsData", menuName = "My Assets/EnvironmentSettings Data")]
public class EnvironmentSettingsData : ScriptableObject
{
    [Header("General settings")]
    [SerializeField] private float _iterationZDistance;
    [SerializeField] private int _iterationCycleOfCreationNum;
    [SerializeField] private float _startEnvironmentZPosition;
    [SerializeField] private float _environmentDistance;

    [Header("Rings settings")]
    [SerializeField] private float _ringDistance;
    [SerializeField] private float _leftRingX;
    [SerializeField] private float _middleRingX;
    [SerializeField] private float _rightRingX;
    [SerializeField] private float _ringY;

    [Header("Spikes settings")]
    [SerializeField] private float _spikeDistance;
    [SerializeField] private float _leftSpikeX;
    [SerializeField] private float _middleSpikeX;
    [SerializeField] private float _rightSpikeX;
    [SerializeField] private float _movableSpikeDistance;
    [SerializeField] private float _spikeY;

    [Header("Amount of elements")]
    [SerializeField] private int _oneRingColumnAmount;
    [SerializeField] private int _ringColumnsAmount;
    [SerializeField] private int _curvedRingColumnAmount;
    [SerializeField] private int _spikeGroupAmount;
    [SerializeField] private int _movableSpikeAmount;

    public float IterationZDistance { get { return _iterationZDistance; } }
    public int IterationCycleOfCreationNum { get { return _iterationCycleOfCreationNum; } }
    public float StartEnvironmentZPosition { get { return _startEnvironmentZPosition; } }
    public float EnvironmentDistance { get { return _environmentDistance; } }
    public float RingDistance { get { return _ringDistance; } }
    public float LeftRingX { get { return _leftRingX; } }
    public float MiddleRingX { get { return _middleRingX; } }
    public float RightRingX { get { return _rightRingX; } }
    public float RingY { get { return _ringY; } }
    public float SpikeDistance { get { return _spikeDistance; } }
    public float LeftSpikeX { get { return _leftSpikeX; } }
    public float MiddleSpikeX { get { return _middleSpikeX; } }
    public float RightSpikeX { get { return _rightSpikeX; } }
    public float MovableSpikeDistance { get { return _movableSpikeDistance; } }
    public float SpikeY { get { return _spikeY; } }
    public int OneRingColumnAmount { get { return _oneRingColumnAmount; } }
    public int RingColumnsAmount { get { return _ringColumnsAmount; } }
    public int CurvedRingColumnAmount { get { return _curvedRingColumnAmount; } }
    public int SpikeGroupAmount { get { return _spikeGroupAmount; } }
    public int MovableSpikeAmount { get { return _movableSpikeAmount; } }
}
