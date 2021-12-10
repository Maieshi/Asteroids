using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthVisualizer : MonoBehaviour
{
    public List<Image> health = new List<Image>();

    GridLayoutGroup group;

    

    public void OnDamage()
    {
        if(health.Count!=0)
        {
            Image image = health[0];
            health.Remove(image);
            Destroy(image);
        }
    }
}
