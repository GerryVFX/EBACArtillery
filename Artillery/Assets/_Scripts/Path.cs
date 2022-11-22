using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public float minDistancePoints = 0.1f;

    LineRenderer line;
    GameObject _lineTarget;
    List<Vector3> points;

    public GameObject lineTarget
    {
        get => _lineTarget;
        set
        {
            _lineTarget = value;
            if (_lineTarget != null)
            {
                line.enabled = false;
                points = new List<Vector3>();
                AddPoint();
            }
        }
    }

    public Vector3 lastPoint
    {
        get
        {
            if(points == null)
            {
                return (Vector3.zero);
            }
            return (points[points.Count - 1]);
        }
    }

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.enabled = false;
        points = new List<Vector3>();
    }

    private void FixedUpdate()
    {
        if(_lineTarget == null)
        {
            if(CameraFollow.target != null)
            {
                if(CameraFollow.target.tag== "Bullet")
                {
                    lineTarget = CameraFollow.target;
                }
                else return; 
            }
            else return;
        }
        AddPoint();
        if (CameraFollow.target == null) lineTarget = null;
    }

    public void AddPoint()
    {
        Vector3 point = _lineTarget.transform.position;
        if (points.Count > 0 && (point - lastPoint).magnitude < minDistancePoints)
        {
            return;
        }
        points.Add(point);
        line.positionCount = points.Count;
        line.SetPosition(points.Count - 1, lastPoint);
        line.enabled = true;
    }
}
