using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Timer {

    public float deltaTime;

    [HideInInspector] public UnityEvent EvSignal;

    private IEnumerator coroutine;

    public void SetDeltaTime(float val) {
        deltaTime = val;
    }

    public void StartStop(bool on, IEnumerator enumerator) {
        if (Settings.Singleton) {
            if (on) {
                if (coroutine == null) {
                    coroutine = enumerator;
                    Settings.Singleton.StartCoroutine(coroutine);
                }
            } else {
                if (coroutine != null) {
                    Settings.Singleton.StopCoroutine(coroutine);
                    coroutine = null;
                }
            }
        }
    }

    

    public virtual void Tik(bool on) 
    {
        StartStop(on, NumTik(deltaTime));
    }

    public virtual void PauseTik(bool on) 
    {
        StartStop(on, NumPauseTik(deltaTime));
    }
    

    private IEnumerator NumTik(float waitTime) 
    {
        while (true) 
        {
            EvSignal.Invoke();
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator NumPauseTik(float waitTime) 
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            EvSignal.Invoke();
        }
    }
}
