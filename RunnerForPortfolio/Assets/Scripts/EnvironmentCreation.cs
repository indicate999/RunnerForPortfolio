using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCreation : MonoBehaviour
{
    [SerializeField] private GameObject _ground;
    [SerializeField] private GameObject _ring;
    [SerializeField] private GameObject _spike;
    [SerializeField] private GameObject _movableSpike;

    [SerializeField] private EnvironmentSettingsData  _environmentSettings;

    [SerializeField] private Transform playerTransform;

    private float _environmentZposition;
    private float _groundZsize;
    private float _groundZposition = 0;

    

    private void Awake()
    {
        _groundZsize = _ground.GetComponent<PlaneContainer>().Plane.GetComponent<Renderer>().bounds.size.z;
    }

    void Start()
    {
        _environmentZposition = _environmentSettings.StartEnvironmentZPosition;
    }

    private void Update()
    {
        CreateEnvironment();
    }

    private void CreateEnvironment()
    {
        if (playerTransform.position.z + _environmentSettings.IterationZDistance > _environmentZposition)
        {
            for (int i = 0; i < _environmentSettings.IterationCycleOfCreationNum; i++)
            {
                int randomRingType = Random.Range(0, 3);

                if (randomRingType == 0)
                    AddOneRingColumn(_environmentSettings.OneRingColumnAmount, ref _environmentZposition);
                else if (randomRingType == 1)
                    AddRingColumns(_environmentSettings.RingColumnsAmount, ref _environmentZposition);
                else
                    AddCurvedRingColumn(_environmentSettings.CurvedRingColumnAmount, ref _environmentZposition);

                _environmentZposition += _environmentSettings.EnvironmentDistance;

                int randomSpikeType = Random.Range(0, 2);

                if (randomSpikeType == 0)
                    AddSpikeGroup(_environmentSettings.SpikeGroupAmount, ref _environmentZposition);
                else
                    AddMovableSpikeGroup(_environmentSettings.MovableSpikeAmount, ref _environmentZposition);

                _environmentZposition += _environmentSettings.EnvironmentDistance;
            }

            while (_groundZposition < _environmentZposition)
            {
                Instantiate(_ground, new Vector3(0, 0, _groundZposition), Quaternion.identity);

                _groundZposition += _groundZsize;
            }
        }
    }

    private void CreateRing(float x, float posZ)
    {
        Instantiate(_ring, new Vector3(x, _environmentSettings.RingY, posZ), Quaternion.identity);
    }

    private void CreateSpike(float x, float posZ)
    {
        Instantiate(_spike, new Vector3(x, _environmentSettings.SpikeY, posZ), Quaternion.identity);
    }

    private void CreateMovableSpike(float posZ)
    {
        Instantiate(_movableSpike, new Vector3(0, _environmentSettings.SpikeY, posZ), Quaternion.identity);
    }

    private void AddSpikeGroup(int spikeNum, ref float posZ)
    {
        float[] randomArray = new float[] { _environmentSettings.LeftSpikeX, _environmentSettings.MiddleSpikeX, _environmentSettings.RightSpikeX };
        float lastRandomX = -100;

        for (int i = 0; i < spikeNum; i++)
        {
            float randomX = randomArray[Random.Range(0, randomArray.Length)];

            while (randomX == lastRandomX)
            {
                randomX = randomArray[Random.Range(0, randomArray.Length)];
            }

            CreateSpike(randomX, posZ);
            lastRandomX = randomX;
            posZ += _environmentSettings.SpikeDistance;
        }

    }

    private void AddMovableSpikeGroup(int movableSpikeNum, ref float posZ)
    {
        for (int i = 0; i < movableSpikeNum; i++)
        {
            CreateMovableSpike(posZ);
            posZ += _environmentSettings.MovableSpikeDistance;
        }
    }

    private void AddOneRingColumn(int ringsNum, ref float posZ)
    {
        float[] randomArray = new float[] { _environmentSettings.LeftRingX, _environmentSettings.MiddleRingX, _environmentSettings.RightRingX };
        float randomDirection = randomArray[Random.Range(0, randomArray.Length)];

        for (int i = 0; i < ringsNum; i++)
        {
            CreateRing(randomDirection, posZ);
            posZ += _environmentSettings.RingDistance;
        }
    }

    private void AddRingColumns(int ringsNum, ref float posZ)
    {
        for (int i = 0; i < ringsNum; i++)
        {
            CreateRing(_environmentSettings.LeftRingX, posZ);
            CreateRing(_environmentSettings.MiddleRingX, posZ);
            CreateRing(_environmentSettings.RightRingX, posZ);
            posZ += _environmentSettings.RingDistance;
        }
    }

    private void AddCurvedRingColumn(int ringsNum, ref float posZ)
    {
        float distanceX = Mathf.Abs(_environmentSettings.LeftRingX) + Mathf.Abs(_environmentSettings.RightRingX);
        int randomDirection = Random.Range(0, 2);
        float posX;

        if (randomDirection == 0)
            posX = _environmentSettings.LeftRingX;
        else
            posX = _environmentSettings.RightRingX;
        
        for (int i = 0; i < ringsNum; i++)
        {
            CreateRing(posX, posZ);

            if (randomDirection == 0)
                posX += distanceX / ringsNum;
            else
                posX -= distanceX / ringsNum;

            posZ += _environmentSettings.RingDistance;
        }
    }
}
