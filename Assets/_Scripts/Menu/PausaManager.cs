using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaManager : MonoBehaviour
{
    [SerializeField] private GameObject pantallaPausa;
    private bool juegoEnPausa = false;
    private int escenaActualIndex;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoEnPausa)
            {
                Reanudando();
            }
            else
            {
                Pausado();
            }
        }
    }

   public void Pausado()
    {
        juegoEnPausa = true;
        Time.timeScale = 0f;
        pantallaPausa.SetActive(true);

    }

    public void Reanudando()
    {
        juegoEnPausa = false;
        Time.timeScale = 1f;
        pantallaPausa.SetActive(false);
    }

    public void CerrarJuego() // por si queremos agregar opción de cerrar juego.
    {
        Debug.Log("Se cierra el juego");
        Application.Quit();
    }

    public void MenuOpciones()
    {
        SceneManager.LoadScene("Opciones_Menu_Pausa");
        Time.timeScale = 1f;
    }

    public void MenuPrincipal()
    {
        juegoEnPausa = true;
        pantallaPausa.SetActive(true);
        Time.timeScale = 1f;
        escenaActualIndex = SceneManager.GetActiveScene().buildIndex; //probando cambios para el botón continuar, gracias a esto carga escena del menu principal
        SceneManager.LoadScene("Menu_Principal");
        PlayerPrefs.SetInt("EscenaGuardada", escenaActualIndex);//Setea la Escena guardada
    }   //Todo completamente implementado, falta que al continuar se conserve las posiciones, el boton continua el juego.
}
