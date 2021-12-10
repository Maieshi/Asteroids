using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage 
{
    bool SetDamage(int val,ObjectType type = ObjectType.none);
}
