using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : Platform
{
    [SerializeField] Transform endPoint;
    [SerializeField] float speed = 1;
    Vector3 _endPoint;
    Vector3 _startPoint;
    [HideInInspector] public bool _moving;
    [SerializeField] bool automatic;
    bool _movingToStart;
    
    // Start is called before the first frame update
    void Start()
    {
        _startPoint = transform.position;
        _endPoint = endPoint.position;
    }
    
    void FixedUpdate()
    {
        if (automatic)
        {
            if(!_movingToStart) goToEndPoint();
            else goToStartPoint();
            
            if (Vector2.Distance(transform.position, _endPoint) < .1f) _movingToStart = true;
            if (Vector2.Distance(transform.position, _startPoint) < .1f) _movingToStart = false;
        }
        else
        {
            if(_moving && Vector2.Distance(transform.position, _endPoint) > .1f) goToEndPoint();
            if (!_moving && Vector2.Distance(transform.position, _startPoint) > .1f) goToStartPoint();
        }
    }

    void goToStartPoint()
    {
        Vector3 normalized = _startPoint - transform.position;
        normalized.Normalize();
        transform.position += normalized * speed * 0.1f;
    }

    void goToEndPoint()
    {
        Vector3 normalized = _endPoint - transform.position;
        normalized.Normalize();
        transform.position += normalized * speed * 0.1f;
    }
}
