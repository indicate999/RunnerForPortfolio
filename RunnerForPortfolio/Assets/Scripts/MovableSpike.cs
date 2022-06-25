using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableSpike : MonoBehaviour
{
    //The spike moves between these two points
    [SerializeField] private Transform LeftPointPosition;
    [SerializeField] private Transform RightPointPosition;

    //This is the speed at which the spike is moving
    [SerializeField] private float speed;

    //This variable indicates which of the two points the spike is currently moving towards
    private bool point;

    private void Start()
    {
        //The initial location of the spike is chosen randomly between two points
        float randomX = Random.Range(LeftPointPosition.position.x, RightPointPosition.position.x);
        transform.position = new Vector3(randomX, transform.position.y, transform.position.z);

        //The spike begins to move to the point that is closer to him
        if (randomX > 0)
            point = true;
        else
            point = false;
    }

    void Update()
    {
        //Here the movement to a specific point is programmed depending on the value of the variable
        if (point)
            transform.position = Vector3.MoveTowards(transform.position, RightPointPosition.position, speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, LeftPointPosition.position, speed * Time.deltaTime);

        //When the spike reaches one of the points, the variable changes and the spike starts moving towards the other point.
        if (transform.position == RightPointPosition.position)
            point = false;
        else if (transform.position == LeftPointPosition.position)
            point = true;

    }
}
