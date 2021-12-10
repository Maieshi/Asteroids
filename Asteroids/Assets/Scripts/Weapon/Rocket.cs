using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Shell,IMovable
{
    public int speed;

    

    

    private void OnTriggerEnter2D(Collider2D other) {
        if(OnDamage(other))OnDestroy();
        
    }

    public Vector3 Move()
    {
        return transform.up*speed*Time.deltaTime;
    }

    private void Update() {
        transform.position +=Move();
    }


}
