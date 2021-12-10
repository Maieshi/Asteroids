using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : SpaceObject , IMovable 
{
    [HideInInspector]
    public Transform target;

    Vector3 direction;

    public float speed;
    public Vector3 Move()
    {
        return Vector3.MoveTowards(transform.position,target.position,speed*Time.deltaTime);
    }

    
    void Update()
    {
        transform.position = Move();
    }
}
