using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideText : MonoBehaviour
{
    bool isHidden = true;

    public Text text;

    public void Chanhe()
    {
        if(isHidden) text.gameObject.SetActive(true);
        else text.gameObject.SetActive(false);


        isHidden = !isHidden;
    }
}
