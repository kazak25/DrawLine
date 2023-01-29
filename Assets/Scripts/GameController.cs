using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.VersionControl;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private DrawLine _lineDrawer;
    [SerializeField] private Rigidbody _player;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _prefab;
   
    

    private void Awake()
    {
        _lineDrawer.Drawn += OnLineDrawn;
    }

    private void Start()
    {
        var prefab = Instantiate(_prefab, _player.transform);
        
    }

    private void OnDestroy()
    {
        _lineDrawer.Drawn -= OnLineDrawn;
    }
    private void OnLineDrawn()
    {
        var linePoints = _lineDrawer.GetPoints();
        StartCoroutine(MovePlayer(linePoints));
    }

    private IEnumerator MovePlayer(Vector3[] linePoints)
    {
        if (linePoints.Length == 0)
        {
            yield break;
        }

        _player.position = new Vector3(linePoints.First().x, linePoints.First().y, linePoints.First().z);
        var currentpointIndex = 0;
        var lastPointIndex = linePoints.Length - 1;

        while (currentpointIndex < lastPointIndex)
        {
            var metersPassedPerFrame = Time.deltaTime * _speed;
            currentpointIndex = MoveTowards(currentpointIndex, linePoints, metersPassedPerFrame);
            yield return null;
        }
        
    }

    private int MoveTowards(int startIndex, Vector3[] linePoints, float meterPassed)
    {
        var currentPointIndex = startIndex;
        while (true)
        {
            var currentPoint = _player.position;
            var nextPoint = linePoints[currentPointIndex + 1];
            var distanceToNextPoint = Vector3.Distance(currentPoint, nextPoint);

            if (distanceToNextPoint < meterPassed)
            {
                _player.position = new Vector3(nextPoint.x, nextPoint.y, nextPoint.z);
                meterPassed -= distanceToNextPoint;
                currentPointIndex++;
            }

            else
            {
                var percent = meterPassed / distanceToNextPoint;
                var currentPosition = Vector3.Lerp(currentPoint, nextPoint, percent);
                _player.position = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z);
                return currentPointIndex;
            }

            var lastPointIndex = linePoints.Length - 1;
            if (currentPointIndex == lastPointIndex)
            {
                return currentPointIndex;
            }
        }
    }
}