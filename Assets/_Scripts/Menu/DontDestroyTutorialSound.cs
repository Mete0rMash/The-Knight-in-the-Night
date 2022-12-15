using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace LMA
{
    public class DontDestroyTutorialSound : MonoBehaviour
    {
        public static DontDestroyTutorialSound instance;
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
            } 
        }

        //Para Pausar el tema al ir a jugar.
        private void Update()
        {
            if (SceneManager.GetActiveScene().name != "Tutorial")
            {
                DontDestroyTutorialSound.instance.GetComponent<AudioSource>().Pause();
            }

            //Aca abajo esta el arreglo que hice


            else if (SceneManager.GetActiveScene().name == "Tutorial")   // me fijo que sea el tutorial
            {
                if (!DontDestroyAudio.instance.GetComponent<AudioSource>().isPlaying)   // me fijo que no se este reproduciendo
                {
                    DontDestroyAudio.instance.GetComponent<AudioSource>().Play(); // reproduzco
                }
            }
        }
    }
}
