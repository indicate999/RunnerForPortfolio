using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableSpike : MonoBehaviour
{
    [SerializeField] private Transform _leftPointPosition;
    [SerializeField] private Transform _rightPointPosition;

    [SerializeField] private float _speed;

    private bool _currentPoint;

    private void Start()
    {
        SetSpikeRandomPosition();
    }

    private void Update()
    {
        MoveSpike();
    }

    private void SetSpikeRandomPosition()
    {
        float randomX = Random.Range(_leftPointPosition.position.x, _rightPointPosition.position.x);
        transform.position = new Vector3(randomX, transform.position.y, transform.position.z);

        _currentPoint = randomX > 0;
    }

    private void MoveSpike()
    {
        if (_currentPoint)
            transform.position = Vector3.MoveTowards(transform.position, _rightPointPosition.position, _speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, _leftPointPosition.position, _speed * Time.deltaTime);

        if (transform.position == _rightPointPosition.position)
            _currentPoint = false;
        else if (transform.position == _leftPointPosition.position)
            _currentPoint = true;
    }
}
