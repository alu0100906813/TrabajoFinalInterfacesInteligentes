using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Códigos de objetos:
 * "VIDA" -> Para las vidas del personale
 * "AMMO" -> Para la munición del personaje
 */


public class objetoRecolectable : MonoBehaviour
{
    public delegate bool recolectarObjeto(string codigoObjeto);
    public static event recolectarObjeto objetoRecolectado;
    public AudioSource audioSource_;

    public GameObject player_;

    // https://www.youtube.com/watch?v=SRhXxhP0ZQY&ab_channel=Academiadevideojuegos
    public Vector3 velocidadRotacion = new Vector3(0f, 1f, 0f);
    public string codigoObjeto = "VIDA";
    // Start is called before the first frame update
    void Start()
    {
        player_ = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(velocidadRotacion);
        if (Vector3.Distance(transform.position, player_.GetComponent<Transform>().position) < 2f)
            // Aquí se lanzaría un evento junto con el código del objeto
            // No olvidemos deshacer el evento en el caso de que obtengamos el objeto
            // Puede ser que el personaje tenga completo ya el objeto (Por ejemplo, tenga ya todas las vidas).
            // En ese caso, no se recolecta el objeto
            if(objetoRecolectado(codigoObjeto))
            {
                audioSource_.Play();
                Destroy(transform.parent.gameObject); // Eliminamos el padre, es decir, la luz del recolectable
                // Destroy(this.gameObject);
            }
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     if(collision.gameObject.name == "Player")
    //     {
            
    //     }
    // }

    
}
