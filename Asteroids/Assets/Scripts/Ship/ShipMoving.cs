using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ShipMoving : MonoBehaviour, IMovable, IRotatable
{
    [HideInInspector]
    public  Vector3 direction;
    
    [Header("Набор скорости за кадр")]
    [SerializeField]
    [Range(.1f,6f)]
    float acceleration ;

    [Header("Потеря скорости за кадр")]
    [SerializeField]
    [Range(.1f,6f)]
    float deceleration ;

    [Header("Скорость поворота")]
    [SerializeField]
    [Range(.1f,6f)]
    float rotationSpeed;

    [Header("Максимальная итоговая скорость")]
    [SerializeField]
    [Range(.1f,6f)]
    float maxSpeed ;

    [Header("Максимальный занос")]
    [SerializeField]
    [Range(.1f,6f)]
    float maxInertiaForce ;

    [Header("Максимальное ускорение")]
    [SerializeField]
    [Range(.1f,6f)]
    float maxTractionForce ;

    [HideInInspector]
    public bool canMove = true;
    

    

    void Start()
    {
       

        direction =  tractionForce = inertia = Vector3.zero;
        tractionScale = inertiaScale = 0;

        if(acceleration==deceleration)acceleration +=.05f;
        else if(acceleration<deceleration)acceleration = Interlocked.Exchange(ref deceleration,acceleration);
    }


    float isRotating,tractionScale,inertiaScale;
    bool isFloatng;

    Vector3 tractionForce , inertia;

    public Vector3 Move()
    {
        isFloatng = Input.GetKey(KeyCode.UpArrow);
        isRotating = Input.GetAxis("Horizontal");

        if(isFloatng&&canMove)
        {
            tractionScale = 
            tractionScale+acceleration>maxTractionForce

                ?maxTractionForce

                :tractionScale+ acceleration;
        }
        else
        {
            tractionScale = tractionScale-deceleration<0?0:tractionScale-deceleration;
        }
        
        tractionForce= VectorCreator.ScaleNClamp(transform.up,tractionScale*Time.deltaTime,maxTractionForce);
        

        if(isRotating!=0&&isFloatng&&canMove)
        {
            
            if(inertiaScale+(acceleration/2)*-isRotating<-maxInertiaForce||inertiaScale+(acceleration/2)*-isRotating>maxInertiaForce)
            inertiaScale = maxInertiaForce*-Mathf.Sign(isRotating);  
            
            else
            inertiaScale+=(acceleration/2)*-isRotating;
             
        }
        else 
        {
            if(inertiaScale>=0)inertiaScale= inertiaScale-deceleration<=0?0:inertiaScale-deceleration;
            else if(inertiaScale<0) inertiaScale= inertiaScale+deceleration>=0?0:inertiaScale+deceleration;
            
        }
       
        inertia = VectorCreator.ScaleNClamp(transform.right,inertiaScale*Time.deltaTime,maxInertiaForce);

        
        
        direction = VectorCreator.SumNClamp(inertia,tractionForce,maxSpeed);


        
        return direction;
    
    }

    float rotation;
    public Vector3 Rotate()
    {

        rotation = Input.GetAxis("Horizontal")*rotationSpeed;
        if(rotation!=0)return -new Vector3(0,0,rotation);
        else return Vector3.zero;
    }

    

    
    
    void FixedUpdate()
    {
        
        transform.Rotate(Rotate());
        transform.position += Move();

        // Debug.DrawRay(transform.position,direction*10,Color.red);
        //  Debug.DrawRay(transform.position,tractionForce*10,Color.blue);
        // Debug.DrawRay(transform.position,inertia*10,Color.green);
       


    }

  
    
}
