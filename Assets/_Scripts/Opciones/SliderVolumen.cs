using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolumen : MonoBehaviour
{
    public Slider sliderV;
    public float sliderValue;
    public Image imagenMute;
    // Start is called before the first frame update
    void Start()
    {
        sliderV.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f); //Guardo el valor de mi slider
        AudioListener.volume = sliderV.value;//Saco el volumen de mi juego con el valor de 0 a 1
        RevisoSiEstaMute();
    }

    public void CambioSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue); //le pongo valor al vlomuenAudio
        AudioListener.volume = sliderV.value;  
        RevisoSiEstaMute(); //para activar imagen de mute
    }

    public void RevisoSiEstaMute() //me fijo si esta en mute
    {
        if (sliderValue == 0)
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
    }
}
