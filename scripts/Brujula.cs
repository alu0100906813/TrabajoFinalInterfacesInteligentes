using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brujula : MonoBehaviour
{
    // Start is called before the first frame update

    private Text campoTextoBrujula_;

    void Start()
    {
        Input.location.Start();
        Input.compass.enabled = true;
        campoTextoBrujula_ = GameObject.Find("CampoBrujula").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        campoTextoBrujula_.text = obtenerCoordenadas().ToString();
    }


    bool estaActivada()
    {
        return Input.compass.enabled;
    }

    void activarYDesactivar()
    {
        Input.compass.enabled = !Input.compass.enabled;
    }
  
    public float obtenerCoordenadas()
    {
        if(!estaActivada())
        {
            return 0.0f;
        } else
        {
            return Input.compass.trueHeading;
        }
    }

}
