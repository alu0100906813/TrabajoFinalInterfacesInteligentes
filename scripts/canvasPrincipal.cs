using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class canvasPrincipal : MonoBehaviour
{


    private AudioSource audioSource_;
    private avisoPantalla textoAviso_;

    private int vidasActuales_;
    private RawImage[] vectorVidasActuales_;

    private Texture imagenVidaCompleta_;
    private Texture imagenVidaVacia_;

    private int maximoVidas_; // OJO, hace falta más cambios aparte de esta variable para cambiar el máximo de vidas
    private int puntuacion_;
    public Text campoPuntuacion_;

    private int ammo_;
    private Text campoAmmo_;
    public int maxAmmo_;

    private float tiempoEspera_;

    // Objetos recolectados por el usuario
    // Máx info de Maps: https://www.dotnetperls.com/map
    private string[] objetosTotales_;
    private Dictionary<string, bool> objetosRecolectados_;
    private Dictionary<string, RawImage> objetosRecolectadosImagen_;
    private string[] nombreObjetos;

    public Color colorDeshabilitado;
    public Color colorHabilitado;

    // Start is called before the first frame update
    void Start()
    {
        textoAviso_ = GameObject.Find("Avisos").GetComponent<avisoPantalla>();
        textoAviso_.mostrarAviso("Encuentra los tres objetos para arrancar el coche");
        maximoVidas_ = 3;
        tiempoEspera_ = Time.time;
        imagenVidaCompleta_ = GameObject.Find("CorazonLleno").GetComponent<RawImage>().texture;
        imagenVidaVacia_ = GameObject.Find("CorazonVacio").GetComponent<RawImage>().texture;
        vectorVidasActuales_ = new RawImage[3];
        resetearVidas();
        campoPuntuacion_ = GameObject.Find("Puntuacion").GetComponent<Text>();
        setPuntacion(0);
        campoAmmo_ = GameObject.Find("Ammo").GetComponent<Text>();
        setAmmo(1);
        maxAmmo_ = 20;
        objetoRecolectable.objetoRecolectado += recolectarObjeto;
        nombreObjetos = new string[] {"Bateria", "Gasolina", "Llave"};
        colorDeshabilitado = new Color(0.2f, 0.2f, 0.2f, 1f);
        colorHabilitado = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        audioSource_ = GetComponent<AudioSource>();
        resetearContadorObjetos();
    }

    // Update is called once per frame
    void Update()
    {
        if (vidasActuales_ == 1 && !audioSource_.isPlaying)
            audioSource_.Play();
        else if (vidasActuales_ > 1)
            audioSource_.Stop();
    }

    // Se ha perdido la última vida :(
    void gameOver()
    {
        // GameOver :(
        SceneManager.LoadScene("gameOver", LoadSceneMode.Single);

        // Aquí podría haber un evento
    }

    // Vidas
    void resetearVidas()
    {
        vidasActuales_ = maximoVidas_;
        for (int i = 0; i < vidasActuales_; ++i)
        {
            vectorVidasActuales_[i] = GameObject.Find("Corazon" + (i + 1)).GetComponent<RawImage>();
            vectorVidasActuales_[i].texture = imagenVidaCompleta_;
        }
    }

    bool vidasCompletas() // True si tenemos todas las vidas
    {
        return vidasActuales_ == maximoVidas_;
    }

    // Si pierde la última vida, pues game over
    public void perderVida()
    {
        if (Time.time - tiempoEspera_ > 5f){
            vidasActuales_ = vidasActuales_ - 1;
            tiempoEspera_ = Time.time;
            setPuntacion(-100);
            vectorVidasActuales_[vidasActuales_].texture = imagenVidaVacia_;
            if (vidasActuales_ == 0)
            {
                gameOver();
            }
        }
    }

    void ganarVida()
    {
        if (vidasActuales_ != maximoVidas_)
        {
            vectorVidasActuales_[vidasActuales_].texture = imagenVidaCompleta_;
            setPuntacion(50);
            vidasActuales_ = vidasActuales_ + 1;
        } // En caso contrario ya tenemos todas las vidas, por lo tanto no podemos incrementar más
    }

    // Puntuación
    private void setPuntacion(int puntuacion)
    {
        if(puntuacion + puntuacion < 0)
        {
            puntuacion = 0;
        } else
        {
            puntuacion = puntuacion + puntuacion;
        }
        campoPuntuacion_.text = $"Puntuación: {puntuacion}";
    }
    
    void anadirPuntuacion(int puntuacion)
    {
        setPuntacion(puntuacion_ + puntuacion);
    }

    void resetearPuntacion()
    {
        setPuntacion(0);
    }

    int getPuntuacion()
    {
        return puntuacion_;
    }
    
    // Munición
    private void setAmmo(int currentAmmo)
    {
        ammo_ = currentAmmo;
        campoAmmo_.text = $"{currentAmmo}";
    }

    void anadirAmmo(int newAmmo)
    {
        setPuntacion(50);
        setAmmo(ammo_ + newAmmo);
    }

    public void reducirAmmo()
    {
        setAmmo(ammo_ - 1);
    }

    void resetearAmmo()
    {
        setAmmo(1);
    }


    public int getAmmo()
    {
        return ammo_;
    }

    int getMaxAmmo()
    {
        return maxAmmo_;
    }

    bool ammoCompleto()
    {
        return ammo_ == maxAmmo_;
    }

    // Los objetos necesarios para entrar en el coche
    void resetearContadorObjetos()
    {
        objetosRecolectados_ = new Dictionary<string, bool>();
        objetosRecolectadosImagen_ = new Dictionary<string, RawImage>();
        for (int i = 0; i < nombreObjetos.Length; ++i)
        {
            objetosRecolectados_.Add(nombreObjetos[i], false);
            objetosRecolectadosImagen_.Add(nombreObjetos[i], GameObject.Find(nombreObjetos[i]).GetComponent<RawImage>()); 
        }

        foreach(var imagen in objetosRecolectadosImagen_)
        {
            imagen.Value.color = colorDeshabilitado;
        }
    }

    void objetoObtenido(string nombreObjeto)
    {
        objetosRecolectados_[nombreObjeto] = true;
        objetosRecolectadosImagen_[nombreObjeto].color = colorHabilitado;
        setPuntacion(100);
        // Aquí comprobamos si ha obtenido todos los objetos. 
        // En caso de que así se, ejecutamos un evento
        if(objetosCompletos())
        {
            textoAviso_.mostrarAviso("Tienes los tres objetos. Dirígete al coche");
            setPuntacion(300);
            GameObject.Find("Player").GetComponent<BandidoEnterToCar>().car_enabled_ = true;
            // Lanzamos el evento
        }
    }

    // Comprueba si ya tenemos todos los objetos
    bool objetosCompletos()
    {
        int objetosEncontrados = 0;
        foreach(var objeto in objetosRecolectados_)
        {
            if(objeto.Value)
            {
                objetosEncontrados = objetosEncontrados + 1;
            }
        }
        return objetosEncontrados == objetosRecolectados_.Count;
    }

    // Este método se puede mejorar mucho, pero no hay tiempo
    bool recolectarObjeto(string codigoObjeto)
    {
        if(codigoObjeto == "VIDA")
        {
            if(vidasCompletas())
            {
                return false;
            }
            ganarVida();
            return true;
        }
        if(codigoObjeto == "AMMO")
        {
            if(ammoCompleto())
            {
                return false;
            }
            setAmmo(ammo_ + 1);
            return true;
        }
        // A partir de aquí, son objetos que tenemos que recolectar
        objetoObtenido(codigoObjeto);
        return true;
    }
}
