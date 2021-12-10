using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {  
        Disable();
    }

    void Disable()
    {
        
        StartCoroutine("Destroy");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    // Update is called once per frame
    
}
