using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableSpike : MonoBehaviour
{
    public Transform LeftPointPosition;
    public Transform RightPointPosition;
    public float speed;
    private bool point;

    // Update is called once per frame
    private void Start()
    {
        float randomX = Random.Range(LeftPointPosition.position.x, RightPointPosition.position.x);
        transform.position = new Vector3(randomX, transform.position.y, transform.position.z);
        if (randomX > 0)
            point = true;
        else
            point = false;
    }

    void Update()
    {
        if (point)
            transform.position = Vector3.MoveTowards(transform.position, RightPointPosition.position, speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, LeftPointPosition.position, speed * Time.deltaTime);

        if (transform.position == RightPointPosition.position)
            point = false;
        else if (transform.position == LeftPointPosition.position)
            point = true;

    }
}
