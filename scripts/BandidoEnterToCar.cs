using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BandidoEnterToCar : MonoBehaviour
{
    public GameObject car;
    public Rigidbody car_rb;
    public Transform car_tf;
    private bool been_in_car = false;
    public Camera characterCamera;
    public bool car_enabled_ = false;
    private string output = "Pulsa Triángulo para entrar en el vehículo";

    public float rotationSpeed = 60f;
    

    private void hide(bool status){
        GetComponent<Renderer>().enabled = status;
    }



    void carGetIn(){
        // been_in_car = true;
        // GetComponent<Rigidbody>().detectCollisions = false;
        // hide(false);
        // characterCamera.gameObject.transform.SetParent(car_tf);
        // Destroy(this.gameObject);
        // characterCamera.gameObject.transform.position = car_tf.position;
        // characterCamera.gameObject.transform.position += new Vector3(-.95f, 1f, -.35f);
        SceneManager.LoadScene("Final", LoadSceneMode.Single);


    }
    void Update(){
        car_rb = car.GetComponent<Rigidbody>();
        car_tf = car.GetComponent<Transform>();

            
        if (Vector3.Distance(transform.position, car_tf.position) < 5f){
            
            if (Input.GetButton("Coche"))
                if (car_enabled_)
                    carGetIn(); 
                else
                    output = "Necesitas encontrar los 3 objetos para arrancar el coche";
            
            
            GameObject.Find("Avisos").GetComponent<avisoPantalla>().mostrarAviso(output);
           

        }                      

        
    }
}
