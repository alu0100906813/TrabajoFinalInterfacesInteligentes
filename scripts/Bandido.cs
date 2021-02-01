using UnityEngine;
using System.Collections;

public class Bandido : MonoBehaviour {

	// Al mover nuestro jugador, recalculamos la dirección a la que van los zombies
	public delegate void direccionMovimiento(Vector3 posicion);
	public static event direccionMovimiento recalcularDireccion;

	public Animator animator;
	public float rotationSpeed;
	float speed_ = 10000f;

	public AudioSource audioSrc;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		rotationSpeed = 120f;
		audioSrc = GetComponent<AudioSource>();

	}


	void Update(){

		recalcularDireccion(transform.position); // Aquí llamamos a la función del evento. Los zombies detectarán nuestra nueva posición

	}
	// Update is called once per frame
	void FixedUpdate () {
		
		if (Input.GetButton("L1"))
			speed_ = 20000f;
		else
			speed_ = 10000f;

		
		gameObject.GetComponent<Rigidbody>().AddRelativeForce(Input.GetAxis("Horizontal")* speed_, -Input.GetAxis("Vertical") * speed_, -Input.GetAxis("Vertical") * speed_);
		// GetComponent<Transform>().Rotate(new Vector3(0, Input.GetAxis("Horizontal"), 0));

		// Permite "apuntar" con el Jostick derecho
		Quaternion deltaRotationD = Quaternion.Euler(
			new Vector3(
					-Input.GetAxis("VerticalR") * 100f, 
					Input.GetAxis("HorizontalR") * 100f,
					0) 
			* Time.deltaTime);

		gameObject.GetComponent<Rigidbody>().MoveRotation(GetComponent<Rigidbody>().rotation * deltaRotationD);
			

	}




	public void OnCollisionEnter(Collision collision){
		GetComponent<Rigidbody>().freezeRotation = true;
	}

	public void OnCollisionExit(Collision collision){
		GetComponent<Rigidbody>().freezeRotation = false;
	}

	public void Idle ()
	{
		animator = GetComponent<Animator>();
		animator.SetBool ("Walk", false);
		animator.SetBool ("SprintJump", false);
		animator.SetBool ("SprintSlide", false);
		if (audioSrc.isPlaying)
			audioSrc.Stop();
	}

	public void Walk ()
	{
		animator = GetComponent<Animator>();
		animator.SetBool ("Walk", true);
		animator.SetBool ("SprintJump", false);
		animator.SetBool ("SprintSlide", false);

		if (audioSrc.isPlaying && audioSrc.pitch == 2f)
			audioSrc.Stop();

		if (!audioSrc.isPlaying)
		{
			audioSrc.pitch = 1f;
			audioSrc.Play();
		}
	}

	public void SprintJump()
	{
		animator = GetComponent<Animator>();
		animator.SetBool ("Walk", false);
		animator.SetBool ("SprintJump", true);
		animator.SetBool ("SprintSlide", false);

		if (audioSrc.isPlaying && audioSrc.pitch == 1f)
			audioSrc.Stop();

		if (!audioSrc.isPlaying)
		{
			audioSrc.pitch = 2f;
			audioSrc.Play();
		}
	}

	public void SprintSlide()
	{
		animator = GetComponent<Animator>();
		animator.SetBool ("Walk", false);
		animator.SetBool ("SprintJump", false);
		animator.SetBool ("SprintSlide", true);

		if (audioSrc.isPlaying && audioSrc.pitch == 1f)
			audioSrc.Stop();

		if (!audioSrc.isPlaying)
		{
			audioSrc.pitch = 2f;
			audioSrc.Play();
		}
	}
}
