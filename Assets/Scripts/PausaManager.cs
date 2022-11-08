using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        if (Input.GetKeyDown(KeyCode.Space))
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
}
