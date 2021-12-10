using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorCreator 
{
    public static Vector3 SumNClamp(Vector3 a, Vector3 b,float maxMagnetude)
    {
        return Vector3.ClampMagnitude(a+b,maxMagnetude);
    }

    public static Vector3 ScaleNClamp(Vector3 original,float scale,float magnetude)
    {
        return Vector3.ClampMagnitude(ScaleVector(original,scale),magnetude);
    }

    public static Vector3 ScaleVector(Vector3 original,float finiteMagnitude)
    {
        Vector3 temp = new Vector3(original.x,original.y,original.z);
        temp = temp.magnitude==0||finiteMagnitude==0?Vector3.zero: temp*(finiteMagnitude/temp.magnitude);
        return temp;
    }
    public static Vector3 CompareVectors(Vector3 a, Vector3 b)
    {
        return (a.magnitude<b.magnitude)? Vector3.zero: a-b;
    }

    public static Vector3 SetRandomVector()
    {
        return new Vector3(Settings.Singleton.MyRand(-1f,1f),Settings.Singleton.MyRand(-1f,1f),0);
    }
}
