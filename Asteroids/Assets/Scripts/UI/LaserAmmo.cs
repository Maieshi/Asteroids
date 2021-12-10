using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class LaserAmmo : MonoBehaviour
{
    public LaserRifle laserRifle;

    Text text;

    private void Start() {
        
        text = GetComponent<Text>();
        text.text ="Laser Ammo Count: "+ laserRifle.maxShotNumber.ToString()+"\r\n"+"Time Betwen Shots:"+ laserRifle.timeBetweenShots.ToString();
    }

    public void OnCangeAmmoCount()
    {
        text.text ="Laser Ammo Count: "+ laserRifle.shotNumber.ToString()+"\r\n"+"Time Betwen Shots:"+ laserRifle.timeBetweenShots.ToString();
    }

}
