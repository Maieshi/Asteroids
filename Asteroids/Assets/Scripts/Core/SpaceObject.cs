using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SpaceObject : MonoBehaviour , IDamage
{
    public int hp,damage,score;
    
    

    public ObjectType type;

    public MyObjEvent EvDeath = new MyObjEvent();

    [HideInInspector]
    public UnityEvent EvDisable = new UnityEvent();


    public virtual bool SetDamage(int val, ObjectType type = ObjectType.none) 
    {
        if (this.type == type) {
            return false;
        } else {
            hp -= val;
            CheckHealth();
            return true;
        }
    }

    public void CheckHealth()
    {
        if(hp<=0)
        {
            OnDeath();
            
        }
    }
    public  void OnDeath()
    {
        EvDeath.Invoke(gameObject);
        EvDisable.Invoke();
        
        StartCoroutine("Destroy");
        
    }

    public virtual IEnumerator  Destroy()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        IDamage damageContact = other.gameObject.GetComponentInParent<IDamage>();
        if (damageContact != null)
        {
            damageContact.SetDamage(damage,type);   
        }
    }
       

}


