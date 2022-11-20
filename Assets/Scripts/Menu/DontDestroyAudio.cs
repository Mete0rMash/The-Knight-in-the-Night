using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyAudio : MonoBehaviour
{
    public static DontDestroyAudio instance;
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
        } //Me reproduce el tema pero al volver al menú se corta... sirve pero tengo que ver como lo arreglo.


            //Con esta linea de codigo el audio se sigue reproduciendo, pero lastimosamente no se destruye en Escena 1
            /*GameObject[] musicObj = GameObject.FindGameObjectsWithTag("MenuMusic");
            if (musicObj.Length > 1)
            {
                Destroy(this.gameObject);
            }
            
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }*/
            

        

    }

    //Para Pausar el tema pero no vuelve a reproducirse cuando se vuelve al menú
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Escenario_1")
        {
            DontDestroyAudio.instance.GetComponent<AudioSource>().Pause();
        }

        //Vuelve a reproducir el tema "Ver bien porq no funca... tal vez lo borre."
        /*if (SceneManager.GetActiveScene().name == "Menu_Principal")
        {
            //DontDestroyAudio.instance.GetComponent<AudioSource>().Play();
            //DontDestroyOnLoad(this.gameObject);
        }   */    
    }
}

