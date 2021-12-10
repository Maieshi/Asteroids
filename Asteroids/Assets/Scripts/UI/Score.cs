using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    int score;

     Text text;

    private void Start() 
    {
        text = GetComponent<Text>();
        score =0;
        UpdateScore(score);
        Spawner.Singleton.scoreEvent.AddListener(UpdateScore);
    }

    void UpdateScore(int val)
    {
        
        score += val;
        text.text ="SCORE \r\n" +score.ToString();
    }
}
