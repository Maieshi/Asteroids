using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Asteroid : SpaceObject , IMovable , IRotatable
{

    public AsteroidTreeNode asteroidNode;

    Vector3 direction,additude;

    float rotation;

    [HideInInspector]
    public float speedScale;

    [Header("Длина вектора направления")]
    [Range(2f,3f)]
    public float maxDirectionMagnetude;

    [Header("Длина добавочного вектора")]
    [Range(.5f,.1f)]
    public float maxAdditudeMagnetude;

    [Header("Максимальный угол поворота")]
    [Range(.1f,3f)]
    public float maxRotation;

    void Start() 
    {
        direction = additude = Vector3.zero;
        direction = Vector3.ClampMagnitude(VectorCreator.SetRandomVector(),maxDirectionMagnetude);
        additude= VectorCreator.ScaleVector(direction,Settings.Singleton.MyRand(0,maxAdditudeMagnetude)*Mathf.Sign(Settings.Singleton.MyRand(-1,1)));
        rotation = Settings.Singleton.MyRand(0,maxRotation)*Mathf.Sign(Settings.Singleton.MyRand(-1,1));

        //Debug.Log(AsteroidTreeNode.GetDepth(asteroidNode));
    }
    
    

    void Update() 
    {
        transform.position+=Move();
        transform.Rotate(Rotate());
    }

    public Vector3 Move()
    {
        return (additude+direction)*Time.deltaTime*speedScale;
    }

    public Vector3 Rotate()
    {
       return new Vector3(0,0,rotation);
    }
}
