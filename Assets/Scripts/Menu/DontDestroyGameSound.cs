using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyGameSound : MonoBehaviour
{
    public static DontDestroyGameSound instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } //Me reproduce el tema pero al volver al menú se corta... Arreglado.
    }

    //Para Pausar el tema al ir al menu.
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu_Principal")
        {
            DontDestroyAudio.instance.GetComponent<AudioSource>().Pause();
        }

        //Aca abajo esta el arreglo que hice

        
        else if(SceneManager.GetActiveScene().name == "Escenario_1")   // me fijo que sea el escenario 1
        {            
            if (!DontDestroyAudio.instance.GetComponent<AudioSource>().isPlaying)   // me fijo que no se este reproduciendo
            {                
                DontDestroyAudio.instance.GetComponent<AudioSource>().Play(); // reproduzco
            }
        }

    }
}

