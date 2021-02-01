using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject canvasPrincipal_;
    private int ammo_;
    // Start is called before the first frame update
    void Start()
    {
        canvasPrincipal_ = GameObject.Find("MyCanvas");
        gameObject.GetComponent<Animator>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        ammo_ = canvasPrincipal_.GetComponent<canvasPrincipal>().getAmmo();
        Debug.Log(ammo_);
        if (ammo_ > 0){
            gameObject.GetComponent<Animator>().enabled = true;
            if (Input.GetMouseButtonDown(0))
                canvasPrincipal_.GetComponent<canvasPrincipal>().reducirAmmo();
        }
        else
            gameObject.GetComponent<Animator>().enabled = false;



    }
}
