using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject Ring;
    public GameObject Spike;
    public GameObject MovableSpike;

    [Header("General settings")]
    public float startZ;
    public float distance;
    public int iterationCycleNum;

    [Header("Rings settings")]
    public float ringDistance;
    public float leftRingX;
    public float middleRingX;
    public float rightRingX;

    [Header("Spikes settings")]
    public float spikeDistance;
    public float leftSpikeX;
    public float middleSpikeX;
    public float rightSpikeX;
    public float movableSpikeDistance;

    [Header("Amount of elements")]
    public int OneRingColumnAmount;
    public int RingColumnsAmount;
    public int CurvedRingColumnAmount;
    public int SpikeGroupAmount;
    public int MovableSpikeAmount;

    // Start is called before the first frame update
    void Start()
    {
        float posZ = startZ;

        for (int i = 0; i < iterationCycleNum; i++)
        {
            int randomRingType = Random.Range(0, 3);

            if (randomRingType == 0)
                AddOneRingColumn(OneRingColumnAmount, ref posZ);
            else if (randomRingType == 1)
                AddRingColumns(RingColumnsAmount, ref posZ);
            else
                AddCurvedRingColumn(CurvedRingColumnAmount, ref posZ);

            posZ += distance;

            int randomSpikeType = Random.Range(0, 2);

            if (randomSpikeType == 0)
                AddSpikeGroup(SpikeGroupAmount, ref posZ);
            else
                AddMovableSpikeGroup(MovableSpikeAmount, ref posZ);

            posZ += distance;

        }
    }

    private void AddSpikeGroup(int spikeNum, ref float z)
    {
        float[] randomArray = new float[] { leftSpikeX, middleSpikeX, rightSpikeX };
        float lastRandomX = -100;

        for (int i = 0; i < spikeNum; i++)
        {
            float randomX = randomArray[Random.Range(0, randomArray.Length)];

            while (randomX == lastRandomX)
            {
                randomX = randomArray[Random.Range(0, randomArray.Length)];
            }

            CreateSpike(randomX, z);
            lastRandomX = randomX;
            z += spikeDistance;
        }

    }

    private void AddMovableSpikeGroup(int movableSpikeNum, ref float z)
    {
        for (int i = 0; i < movableSpikeNum; i++)
        {
            CreateMovableSpike(z);
            z += movableSpikeDistance;
        }
    }

    private void AddOneRingColumn(int ringsNum, ref float z)
    {
        float[] randomArray = new float[] { leftRingX, middleRingX, rightRingX };
        float randomDirection = randomArray[Random.Range(0, randomArray.Length)];

        for (int i = 0; i < ringsNum; i++)
        {
            CreateRing(randomDirection, z);
            z += ringDistance;
        }
    }

    private void AddRingColumns(int ringsNum, ref float z)
    {
        for (int i = 0; i < ringsNum; i++)
        {
            CreateRing(leftRingX, z);
            CreateRing(middleRingX, z);
            CreateRing(rightRingX, z);
            z += ringDistance;
        }
    }

    private void AddCurvedRingColumn(int ringsNum, ref float z)
    {
        float distanceX = Mathf.Abs(leftRingX) + Mathf.Abs(rightRingX);
        int randomDirection = Random.Range(0, 2);
        float posX;
        if (randomDirection == 0)
            posX = leftRingX;
        else
            posX = rightRingX;
        
        for (int i = 0; i < ringsNum; i++)
        {
            CreateRing(posX, z);
            if (randomDirection == 0)
                posX += distanceX / ringsNum;
            else
                posX -= distanceX / ringsNum;

            z += ringDistance;
        }
    }

    private void CreateRing(float x, float z)
    {
        Instantiate(Ring, new Vector3(x, 2.9f, z), Quaternion.identity);
    }

    private void CreateSpike(float x, float z)
    {
        Instantiate(Spike, new Vector3(x, 3.67f, z), Quaternion.identity);
    }

    private void CreateMovableSpike(float z)
    {
        Instantiate(MovableSpike, new Vector3(0, 3.67f, z), Quaternion.identity);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
