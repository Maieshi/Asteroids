using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum WhatChange
{
    x,
    y
}
public class Teleporter : MonoBehaviour
{

    [SerializeField]
    Transform teleportPoint;

    [SerializeField]    
    WhatChange whatChange;



    private void OnTriggerEnter2D(Collider2D other)
    {

        Transform temp = other.transform.root.GetComponent<Transform>();
        if(whatChange==WhatChange.x) temp.position= new Vector3(teleportPoint.position.x,temp.position.y,temp.position.z);
        
        //temp.Translate(new Vector3(teleportPoint.position.x,temp.position.y,temp.position.z));
        else temp.position = new Vector3(temp.position.x,teleportPoint.position.y,temp.position.z);
    }
}
