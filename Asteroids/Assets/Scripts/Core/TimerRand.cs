using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TimerRand : Timer {
    
    public Vector2 deltaRand;

    

    public override void Tik(bool on) {
        deltaTime = Settings.Singleton.MyRand(deltaRand.x, deltaRand.y);
        if(on) EvSignal.AddListener(ChangeDelta);
        else EvSignal.RemoveListener(ChangeDelta);
        base.Tik(on);
    }

    public override void PauseTik(bool on) {
        deltaTime = Settings.Singleton.MyRand(deltaRand.x, deltaRand.y);
        if(on) EvSignal.AddListener(ChangeDelta);
        else EvSignal.RemoveListener(ChangeDelta);
        base.PauseTik(on);
    }

    void ChangeDelta()
    {
        deltaTime = Settings.Singleton.MyRand(deltaRand.x, deltaRand.y);
    }

}
