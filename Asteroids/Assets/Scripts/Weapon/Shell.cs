using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shell : MonoBehaviour
{
    public ObjectType type;
    public float lifeTime;

    public int damage;

    [HideInInspector]
    public Timer destoryTime;

    public  virtual void Start() 
    {
        destoryTime.deltaTime = lifeTime;
        destoryTime.EvSignal.AddListener(OnDestroy);
        destoryTime.PauseTik(true);
    }



    public  void OnDestroy()
    {
        
        Destroy(gameObject);
    }

    public  bool OnDamage(Collider2D other)
    {
        bool damaged = false;

        IDamage damageContact = other.gameObject.GetComponentInParent<IDamage>();

        if (damageContact == null) {
            damageContact = other.gameObject.GetComponent<IDamage>();
        }
        
        if (damageContact != null) {
            damaged =  damageContact.SetDamage(damage, type);
            
        }
        return damaged;
        
    }
}
