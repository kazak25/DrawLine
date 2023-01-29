using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterPatrul : MonoBehaviour
{

    [SerializeField]
    private Transform[] _wayPoints;

    [SerializeField]
    private float _speed;

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _estimatedTimeOfArrival;

    private int _currentPointIndex;
    private float _currentTime;

    private void Awake()
    {
        SetNextPoints();
    }

    private void SetNextPoints()
    {
        var nextPointIndex = (_currentPointIndex + 1) % _wayPoints.Length;

        _startPosition = _wayPoints[_currentPointIndex].position;
        _endPosition = _wayPoints[nextPointIndex].position;

        _estimatedTimeOfArrival = Vector3.Distance(_startPosition, _endPosition) / _speed;

        _currentPointIndex = nextPointIndex;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        var progress = _currentTime / _estimatedTimeOfArrival;
        transform.position = Vector3.Lerp(_startPosition, _endPosition, progress);

        if (_currentTime > _estimatedTimeOfArrival)
        {
            SetNextPoints();
            _currentTime = 0;
        }
    }

}
