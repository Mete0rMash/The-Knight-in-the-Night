using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyGameSound : MonoBehaviour
{
    public static DontDestroyGameSound instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } //Me reproduce el tema pero al volver al menú se corta... Arreglado.
    }

    //Para Pausar el tema al ir a jugar.
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu_Principal")
        {
            DontDestroyGameSound.instance.GetComponent<AudioSource>().Pause();
        }

        //Aca abajo esta el arreglo que hice


        else if (SceneManager.GetActiveScene().name == "Escenario_1")   // me fijo que sea el menu
        {
            if (!DontDestroyGameSound.instance.GetComponent<AudioSource>().isPlaying)   // me fijo que no se este reproduciendo
            {
                DontDestroyGameSound.instance.GetComponent<AudioSource>().Play(); // reproduzco
            }

           
        }
    }
}

