using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditLightController : MonoBehaviour
{

    public bool lightStatus = false;
    public Light spotLight;

    void Awake(){
        spotLight = GameObject.FindWithTag("SpotLight").GetComponent<Light>();
        spotLight.enabled = false;
    }

    private void switchLight(){
        if (lightStatus){
            spotLight.enabled = false;
            lightStatus = false;
        }
        else{
            spotLight.enabled = true;
            lightStatus = true;
        }
    }
    void Update (){
        if (Input.GetButtonDown("Linterna"))
            switchLight();


    }
}
