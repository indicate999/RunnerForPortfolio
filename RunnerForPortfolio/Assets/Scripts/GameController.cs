using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject Ground;
    [SerializeField] private GameObject Ring;
    [SerializeField] private GameObject Spike;
    [SerializeField] private GameObject MovableSpike;

    [Header("General settings")]
    [SerializeField] private float iterationZDistance;
    [SerializeField] private int iterationCycleOfCreationNum;
    [SerializeField] private float startEnvironmentZPosition;
    private float environmentZposition;
    [SerializeField] private float environmentDistance;
    private float groundZsize;
    private float groundZposition = 0;

    [Header("Rings settings")]
    [SerializeField] private float ringDistance;
    [SerializeField] private float leftRingX;
    [SerializeField] private float middleRingX;
    [SerializeField] private float rightRingX;
    [SerializeField] private float ringY;

    [Header("Spikes settings")]
    [SerializeField] private float spikeDistance;
    [SerializeField] private float leftSpikeX;
    [SerializeField] private float middleSpikeX;
    [SerializeField] private float rightSpikeX;
    [SerializeField] private float movableSpikeDistance;
    [SerializeField] private float spikeY;

    [Header("Amount of elements")]
    [SerializeField] private int OneRingColumnAmount;
    [SerializeField] private int RingColumnsAmount;
    [SerializeField] private int CurvedRingColumnAmount;
    [SerializeField] private int SpikeGroupAmount;
    [SerializeField] private int MovableSpikeAmount;

    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //Here you get the length of the earth block along the z axis
        groundZsize = Ground.transform.GetChild(0).GetComponent<Renderer>().bounds.size.z;
         
    }

    void Start()
    {
        environmentZposition = startEnvironmentZPosition;
    }

    private void Update()
    {
        //With this code, all elements of the environment, including the ground, rings and spikes,
        //are generated during the passage of the game, creating an endless level.
        //If the character is at a distance (iterationZDistance) from the end of the generated environment,
        //then a new generation of the environment occurs
        if (playerTransform.position.z + iterationZDistance > environmentZposition)
        {
            //(iterationCycleOfCreationNum) shows how many times the environment creation cycle will occur during each environment generation
            for (int i = 0; i < iterationCycleOfCreationNum; i++)
            {
                //Here, the method of building the environment is randomly selected.
                int randomRingType = Random.Range(0, 3);

                //The variable is sent to the method with the ref modifier so that when the environment generation methods are called in the future,
                //a new environment will be created at following positions
                if (randomRingType == 0)
                    AddOneRingColumn(OneRingColumnAmount, ref environmentZposition);
                else if (randomRingType == 1)
                    AddRingColumns(RingColumnsAmount, ref environmentZposition);
                else
                    AddCurvedRingColumn(CurvedRingColumnAmount, ref environmentZposition);

                //There must be a distance between the groups of the environment
                environmentZposition += environmentDistance;

                int randomSpikeType = Random.Range(0, 2);

                if (randomSpikeType == 0)
                    AddSpikeGroup(SpikeGroupAmount, ref environmentZposition);
                else
                    AddMovableSpikeGroup(MovableSpikeAmount, ref environmentZposition);

                environmentZposition += environmentDistance;
            }

            //The ground is generated to about the same place as the rings and spikes
            while (groundZposition < environmentZposition)
            {
                Instantiate(Ground, new Vector3(0, 0, groundZposition), Quaternion.identity);

                groundZposition += groundZsize;
            }
        }
    }

    //These methods create one environment element of the environment
    private void CreateRing(float x, float posZ)
    {
        Instantiate(Ring, new Vector3(x, ringY, posZ), Quaternion.identity);
    }

    private void CreateSpike(float x, float posZ)
    {
        Instantiate(Spike, new Vector3(x, spikeY, posZ), Quaternion.identity);
    }

    private void CreateMovableSpike(float posZ)
    {
        Instantiate(MovableSpike, new Vector3(0, spikeY, posZ), Quaternion.identity);
    }

    //This method creates a group of spikes, each of which spawns random at one of three locations
    private void AddSpikeGroup(int spikeNum, ref float posZ)
    {
        float[] randomArray = new float[] { leftSpikeX, middleSpikeX, rightSpikeX };
        float lastRandomX = -100;

        for (int i = 0; i < spikeNum; i++)
        {
            float randomX = randomArray[Random.Range(0, randomArray.Length)];

            //If the randomly selected next location repeats the previous one,
            //then the random choice of the spike location will be repeated until there are no repetitions
            while (randomX == lastRandomX)
            {
                randomX = randomArray[Random.Range(0, randomArray.Length)];
            }

            CreateSpike(randomX, posZ);
            lastRandomX = randomX;
            posZ += spikeDistance;
        }

    }

    //This method creates a group of moving spikes
    private void AddMovableSpikeGroup(int movableSpikeNum, ref float posZ)
    {
        for (int i = 0; i < movableSpikeNum; i++)
        {
            CreateMovableSpike(posZ);
            posZ += movableSpikeDistance;
        }
    }

    //This method creates a column of rings in one of three random directions
    private void AddOneRingColumn(int ringsNum, ref float posZ)
    {
        float[] randomArray = new float[] { leftRingX, middleRingX, rightRingX };
        float randomDirection = randomArray[Random.Range(0, randomArray.Length)];

        for (int i = 0; i < ringsNum; i++)
        {
            CreateRing(randomDirection, posZ);
            posZ += ringDistance;
        }
    }

    //This method creates columns of rings in all three directions.
    private void AddRingColumns(int ringsNum, ref float posZ)
    {
        for (int i = 0; i < ringsNum; i++)
        {
            CreateRing(leftRingX, posZ);
            CreateRing(middleRingX, posZ);
            CreateRing(rightRingX, posZ);
            posZ += ringDistance;
        }
    }

    //This method creates a curved line of rings from right to left or left to right.
    private void AddCurvedRingColumn(int ringsNum, ref float posZ)
    {
        //By summing the modules of positions along the x-axis of the left and right extreme points, we get the distance between them
        float distanceX = Mathf.Abs(leftRingX) + Mathf.Abs(rightRingX);
        int randomDirection = Random.Range(0, 2);
        float posX;

        //Here it is randomly chosen whether the rings will go from left to right or from right to left
        if (randomDirection == 0)
            posX = leftRingX;
        else
            posX = rightRingX;
        
        for (int i = 0; i < ringsNum; i++)
        {
            CreateRing(posX, posZ);
            //With these calculations, we evenly distribute the rings along the x-axis
            if (randomDirection == 0)
                posX += distanceX / ringsNum;
            else
                posX -= distanceX / ringsNum;

            posZ += ringDistance;
        }
    }
}
