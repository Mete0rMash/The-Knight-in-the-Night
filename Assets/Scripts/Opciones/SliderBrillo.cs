using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBrillo : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image paneldeBrillo;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        paneldeBrillo.color = new Color(paneldeBrillo.color.r, paneldeBrillo.color.g, paneldeBrillo.color.b, slider.value); //guardo el prefs del brillo aplicado
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);   //seteo el prefs del brillo aplicado
        paneldeBrillo.color = new Color(paneldeBrillo.color.r, paneldeBrillo.color.g, paneldeBrillo.color.b, slider.value);
    }
}
