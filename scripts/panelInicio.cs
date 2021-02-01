using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class panelInicio : MonoBehaviour
{
    // Start is called before the first frame update

    private bool startPanel;
    private bool gameStarted;
    private Image panel;
    private float colorTransparency;
    private float textTransparency;
    private Text textoInicio;

    void Start()
    {
        startPanel = false;
        panel = GetComponent<Image>();
        panel.color = new Color(0, 0, 0, 0);
        textoInicio = GameObject.Find("TextoMenuInicio").GetComponent<Text>();
        textoInicio.color = new Color(0, 0, 0, 0);
        colorTransparency = 0.0f;
        textTransparency = 0.0f;
        gameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Space") && !startPanel)
        {
            startPanel = true;
        }
        if(startPanel)
        {
            if(colorTransparency < 2.5f)
            {
                colorTransparency = colorTransparency + 0.4f * Time.deltaTime;
                panel.color = new Color(0, 0, 0, colorTransparency);
            } else
            {
                if(textTransparency < 4.0f)
                {
                    textTransparency = textTransparency + 0.4f * Time.deltaTime;
                    textoInicio.color = new Color(255, 255, 255, textTransparency);
                } else
                {
                    if(!gameStarted)
                    {
                        gameStarted = true;
                        startGame();
                    }
                }
            }
        }
    }

    // Se llama cuando se ha mostrado todo y queremos empezar el juego
    void startGame()
    {
        Debug.Log("Empieza el juego");
        SceneManager.LoadScene("Proyecto", LoadSceneMode.Single);
        
    }

}
