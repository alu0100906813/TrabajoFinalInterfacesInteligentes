using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class avisoPantalla : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textoAviso_;
    private float colorTexto_;

    void Start()
    {
        textoAviso_ = GetComponent<Text>();
        textoAviso_.color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(colorTexto_ > 0.0f)
        {
            colorTexto_ = colorTexto_ - 0.1f * Time.deltaTime;
            textoAviso_.color = new Color(255, 255, 255, colorTexto_);
        }
    }

    public void mostrarAviso(string aviso)
    {
        textoAviso_.text = aviso;
        colorTexto_ = 1.0f;
    }

}
