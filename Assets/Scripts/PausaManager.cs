using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaManager : MonoBehaviour
{
    [SerializeField] private GameObject pantallaPausa;
    private bool juegoEnPausa = false;
    void Start()
    {
        
    }

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
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Menu_Principal");
        Time.timeScale = 1f;
    }
}
