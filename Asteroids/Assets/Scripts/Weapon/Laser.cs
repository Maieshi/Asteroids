using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Shell
{
    private LineRenderer lr;
    
   public override void Start() 
    {
        base.Start();
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0,transform.position);
        lr.SetPosition(1,transform.position);
        

    }

    
    private void Update() 
    {
         
            lr.SetPosition(0,transform.position);
            RaycastHit2D hit;
            hit = Physics2D.Raycast(transform.position,transform.up*100);
            if(hit.collider)
            {
                lr.SetPosition(1,hit.point);
                OnDamage(hit.collider);
            }
            else lr.SetPosition(1,transform.up*100);
           
        
    }

  
    
}
