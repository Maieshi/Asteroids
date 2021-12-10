using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using Random = UnityEngine.Random;

public enum ObjectType
{
    none,
    
    enemy,

    ship,
}

public class MyObjEvent : UnityEvent<GameObject>
{
}

public class MyNodeEvent : UnityEvent<AsteroidTreeNode>
{
}
public class MyIntEvent : UnityEvent<int>
{
}

public class Settings : MonoBehaviour {

    public static Settings Singleton;

    
    public UnityEvent EvStopGame = new UnityEvent();
    

    
    public void StopGame() {
        EvStopGame.Invoke();
    }

    

    private void Awake() {
        if (Singleton == null) {
            Singleton = this;
        } else if (Singleton == this) {
            Destroy(gameObject);
            return;
        }

        Random.InitState((int)DateTime.Now.Ticks);

    }

    private void OnDestroy() {
        StopAllCoroutines();
    }

    public void ExitGame() {
        Application.Quit();
    }

  

    public float MyRand() {
        return Random.value;
    }

    public float MyRand(float val) {
        return Random.Range(0, val);
    }

    public int MyRand(int val) {
        return Random.Range(0, val);
    }

    public float MyRand(float min, float max) {
        return Random.Range(min, max);
    }

    public int MyRand(int min, int max) {
        return Random.Range(min, max);
    }

    
}
