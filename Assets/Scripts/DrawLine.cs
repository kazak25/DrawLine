using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
   [SerializeField] private float _pointTrackingTreshHold = 0.1f;
   [SerializeField] private float _minDistanceBetweenPoints = 0.1f;
    
    public event Action Drawn;
    private bool _isDrawingMode;
    private LineRenderer _lineRenderer;

    private float _lastAddPointTime;
    // Start is called before the first frame update


    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        { 
            _lineRenderer.positionCount = 0;
            _isDrawingMode = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Drawn?.Invoke();_isDrawingMode = false;
        }

        if (!_isDrawingMode)
        {
            return;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo))
        {
            TryAddNewPoint(hitInfo.point);
        }
    }

    private void TryAddNewPoint(Vector3 hitPoint)
    {
        var isTimeToAddNewPoint = _lastAddPointTime + _pointTrackingTreshHold < Time.time;
        if (!isTimeToAddNewPoint)
        {
            return;
        }

        if (!IsSamePoint(hitPoint))
        {
            _lastAddPointTime = Time.time;
            _lineRenderer.positionCount++;
            _lineRenderer.SetPosition(_lineRenderer.positionCount-1,hitPoint);
        }
    }

    private bool IsSamePoint(Vector3 hitPoint)
    {
        if (_lineRenderer.positionCount == 0)
        {
            return false;
        }

        var lastPoint = _lineRenderer.GetPosition(_lineRenderer.positionCount - 1);
        return Vector3.Distance(lastPoint, hitPoint) < _minDistanceBetweenPoints;
    }

    public Vector3[] GetPoints()
    {
        Vector3[] array = new Vector3[_lineRenderer.positionCount];
        _lineRenderer.GetPositions(array);
        return array;
    }

    public Vector3 GetLastPoint()
    {
        return _lineRenderer.GetPosition(_lineRenderer.positionCount);
    }
}
