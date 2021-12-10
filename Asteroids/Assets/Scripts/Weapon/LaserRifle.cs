using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRifle : Weapon
{
    public override void Shoot()
    {

        if(CanShoot()&&shooting)
        {
            shotNumber--;
            Instantiate(shell,shootPoint.position,shootPoint.rotation,shootPoint);
            EvShoot.Invoke(); 
        }
    }

    public override void Reload()
    {
        
            if(shotNumber<maxShotNumber)
            {
                shotNumber++;
                EvReload.Invoke();
            }
            
    }

}
