using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// https://docs.unity3d.com/ScriptReference/Vector3.MoveTowards.html -> Moverte hacia una posición y ver si estás cerca
// https://answers.unity.com/questions/254130/how-do-i-rotate-an-object-towards-a-vector3-point.html -> Rotar hacia un punto

public class Zombie : MonoBehaviour
{
    private Animator animator_;
    private bool ZombieIsStopped_;
    private Vector3 posicionDestino_;
    private float velocidadMovimiento_;
    private float velocidadRotacion_;
    private float distanciaAtaque_;
    private float distanciaGolpeo_;
    public Canvas canvas_;
    public AudioSource audioSrc;
    public float distanciaVolumen_;
    public float volumen_;
    private float zombiesLife_;

    
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        animator_ = GetComponent<Animator>();
        Bandido.recalcularDireccion += getPlayerPosition;
        // posicionDestino_ = transform.position;
        velocidadMovimiento_ = 1.0f;
        velocidadRotacion_ = 20.0f;
        distanciaAtaque_ = 2.0f;
        distanciaGolpeo_ = 0.7f;
        ZombieIsStopped_ = false;
        zombiesLife_ = 100f;
        distanciaVolumen_ = 30f;
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = 0;
        StartCoroutine(playSound());

        agent = GetComponent<NavMeshAgent>();
    }

    public void OnCollisionEnter(Collision collision){

        GetComponent<Rigidbody>().freezeRotation = true;

        if (collision.gameObject == GameObject.Find("45ACP Bullet_Head(Clone)")){
            zombiesLife_ -= 100;
            StartCoroutine(die());
            Destroy(GameObject.Find("45ACP Bullet_Head(Clone)"));
        }
        
    }



    IEnumerator die (){
        animator_.Play("Z_FallingBack");
        yield return new WaitForSeconds(1);

        Destroy(this.gameObject);
    }

    IEnumerator playSound (){

        yield return new WaitForSeconds(Random.Range(0, 2));

        audioSrc.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (zombiesLife_ > 0)
            if(ZombieIsStopped_)
            {
                animator_.Play("Z_Idle");
            } else
            {
                // Nos movemos a la posición del jugador
                float velocidad = velocidadMovimiento_ * Time.deltaTime;
                agent.speed = velocidad * 15;
                agent.SetDestination(posicionDestino_);
                // transform.position = Vector3.MoveTowards(transform.position, posicionDestino_, velocidad);
                rotarHaciaObjetivo();
                float distancia = Vector3.Distance(transform.position, posicionDestino_);
                if (distancia < distanciaAtaque_)
                { // Si la distancia es inferior a X, entonces atacamos
                    animator_.Play("Z_Attack");
                    if (distancia < distanciaGolpeo_)
                        canvas_.GetComponent<canvasPrincipal>().perderVida();
                } else
                {
                    animator_.Play("Z_Walk_InPlace");
                }

            if (distancia < distanciaVolumen_)
            {
                volumen_ = (1 - distancia / distanciaVolumen_) / 2;
                audioSrc.volume = volumen_;
            }
            }

    }


	public void OnCollisionExit(Collision collision){
		GetComponent<Rigidbody>().freezeRotation = false;
	}


    
    void getPlayerPosition(Vector3 posicionJugador)
    {
        posicionDestino_ = posicionJugador;
    }

    void rotarHaciaObjetivo()
    {
        //find the vector pointing from our position to the target
        Vector3 _direction = (posicionDestino_ - transform.position).normalized;

        if(_direction != Vector3.zero)
        { // Evitamos un mensaje molesto cuando la rotación es 0
            //create the rotation we need to be in to look at the target
            Quaternion _lookRotation = Quaternion.LookRotation(_direction);

            //rotate us over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * velocidadRotacion_);
        }
    }
}
