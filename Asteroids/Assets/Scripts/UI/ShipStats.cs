using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipStats : MonoBehaviour
{

    public ShipMoving ship;
    
    Text text;

    private void Start() {

        text = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ship!=null)
        text.text =  "position: "+ ship.transform.position.ToString()+"\r\n"
                    +"rotation: "+ ship.transform.rotation.ToString()+"\r\n"
                    +"speed vector: "+ ship.direction.ToString()+"\r\n";;
        
    }
}
