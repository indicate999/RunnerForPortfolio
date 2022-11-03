using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableSpike : MonoBehaviour
{
    [SerializeField] private Transform _leftPointPosition;
    [SerializeField] private Transform _rightPointPosition;

    [SerializeField] private float _speed;

    private bool _point;

    private void Start()
    {
        SetSpikeRandomPosition();
    }

    void Update()
    {
        SpikeMovement();
    }

    private void SetSpikeRandomPosition()
    {
        float randomX = Random.Range(_leftPointPosition.position.x, _rightPointPosition.position.x);
        transform.position = new Vector3(randomX, transform.position.y, transform.position.z);

        _point = randomX > 0;
    }

    private void SpikeMovement()
    {
        if (_point)
            transform.position = Vector3.MoveTowards(transform.position, _rightPointPosition.position, _speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, _leftPointPosition.position, _speed * Time.deltaTime);

        if (transform.position == _rightPointPosition.position)
            _point = false;
        else if (transform.position == _leftPointPosition.position)
            _point = true;
    }
}
