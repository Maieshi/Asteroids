using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour
{
    
    public string levelName;

    public void Load()
    {
        gameObject.GetComponent<Button>().interactable = false;
        SceneManager.LoadScene(levelName);
    }

}
