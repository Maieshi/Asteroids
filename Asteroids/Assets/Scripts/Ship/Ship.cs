using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Ship : SpaceObject
{
    

    public int invulnerabilityTime;

    bool isInvulnerabilable = false;

    [HideInInspector]
    public Timer timer;

    public UnityEvent EvDamage = new UnityEvent();

    private void Start() {
        timer.deltaTime = invulnerabilityTime; 
        timer.EvSignal.AddListener(Invulnerability);
        EvDeath.AddListener(Spawner.Singleton.OnObjectDestroy);
    }

    public override bool SetDamage(int val, ObjectType type = ObjectType.none)
    {
        if(!isInvulnerabilable)
        {
            bool isDamaged =base.SetDamage(val, type);
            if(isDamaged)
            {
                EvDamage.Invoke();
                isInvulnerabilable = true;
                timer.PauseTik(true);
                
            }
            return isDamaged;
        }
        else return false;
    }
     
    void Invulnerability()
    {
        
        isInvulnerabilable = false;
        timer.PauseTik(false);
    }

    public override IEnumerator Destroy()
    {
        Settings.Singleton.EvStopGame.Invoke();
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<ShipMoving>().canMove=false;
        yield return new WaitForSeconds(1.5f);
        EvDeath.Invoke(gameObject);
        Destroy(gameObject);

    }
}
