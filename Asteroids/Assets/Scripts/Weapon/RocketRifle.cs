using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketRifle : Weapon
{
    public override void Reload()
    {
        
        if(shotNumber<maxShotNumber)shotNumber++;
    }

    public override void Shoot()
    {
        
        if(CanShoot()&&shooting)
        {
            
            shotNumber--;
            Instantiate(shell,shootPoint.position,Quaternion.LookRotation(shootPoint.forward,shootPoint.up));
            EvShoot.Invoke();
        }
    }
}
