using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    public Shell shell;
    public Transform shootPoint;

    [HideInInspector]
    public Timer shootTimer,reloadTimer;

    public int  maxShotNumber;

    [HideInInspector]
    public int shotNumber ;

    public KeyCode key;

    public float timeBetweenShots, reloadSpeed;

    public UnityEvent EvReload, EvShoot;

    [HideInInspector]
    public bool shooting;
    private void Start() {
        Initialize();
    }

    public void Initialize()
    {
        shotNumber = maxShotNumber;
        shooting = false;
        shootTimer.deltaTime = timeBetweenShots;
        shootTimer.EvSignal.AddListener(Shoot);
        reloadTimer.deltaTime = reloadSpeed;
        reloadTimer.EvSignal.AddListener(Reload);
        StartReloading();
        StartShooting();
    }

    public bool CanShoot()
    {
        if(shotNumber<=0)return false;
        else return true;
    }

    public abstract void Shoot();

    public abstract void Reload();

    

    public void StartShooting()
    {
        shootTimer.Tik(true);
    }
    public void EndShooting()
    {
        shootTimer.Tik(false);
    }

    public void StartReloading()
    {
        reloadTimer.Tik(true);
    }

    public void StopReloading()
    {
        reloadTimer.Tik(false);
    }

    private void FixedUpdate() 
    {
        
        if(Input.GetKey(key))shooting = true;
        else shooting = false;
    }

}
