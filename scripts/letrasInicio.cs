using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letrasInicio : MonoBehaviour
{
    private bool agrandandoOAchicando_;
    private float tamanoActual_;
    private int posicionActual_;
    // Start is called before the first frame update
    void Start()
    {
        posicionActual_ = 0;
        tamanoActual_ = 1.0f;
        agrandandoOAchicando_ = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(agrandandoOAchicando_)
        {
            tamanoActual_ = tamanoActual_ + 0.08f * Time.deltaTime;
            posicionActual_ = posicionActual_ + 1;
        } else
        {
            tamanoActual_ = tamanoActual_ - 0.08f * Time.deltaTime;
            posicionActual_ = posicionActual_ - 1;
        }
        transform.localScale = new Vector3(tamanoActual_, tamanoActual_, tamanoActual_);
        if(posicionActual_ == 0 || posicionActual_ == 100)
        {
            agrandandoOAchicando_ = !agrandandoOAchicando_;
        }
    }
}
